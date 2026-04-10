using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelProgress : MonoBehaviour
{
    //Положение стартового триггера
    [SerializeField] Transform startPoint;
    //Положение финишного триггера
    [SerializeField] Transform finishPoint;
    //Ссылка на картинку, которая будет заполнять прогресс бар
    [SerializeField] Image progressBar;
    //Переменная для определения длинны уровня
    float levelLength;
    //Ссылка на UI Таймера
    [SerializeField] TextMeshProUGUI timerText;
    //Запущен ли таймер?
    bool timerRunning = false;
    //Счетчик времени
    float timer = 0f;
    //Ссылка на текст лучшего результата
    [SerializeField] TextMeshProUGUI bestTimeText;
    [SerializeField] TextMeshProUGUI coin;
    //Переменная для лучшего результата
    float bestTime = Mathf.Infinity;
    float coins = 150f;
    // Start is called before the first frame update
    void Start()
    {
        levelLength = finishPoint.position.z - startPoint.position.z;
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
        }
        else
        {
            bestTimeText.text = "Best Time: --";
        }
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetFloat("Coins");
            coin.text = "Coins: " + coins.ToString("F2");
        }
        else
        {
            coin.text = "Coins: 150";
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = transform.position.z - startPoint.position.z;
        float progress = Mathf.Clamp01(distance / levelLength);
        progressBar.fillAmount = progress;
        if (timerRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F2");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("BestTime");
            PlayerPrefs.DeleteKey("Coins");
            bestTime = Mathf.Infinity;
            bestTimeText.text = "Best Time: --";
            coin.text = "Coins: 150";
        }
    }
    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Start") && !timerRunning)
        {
            timerRunning = true;
        }

        if (other.CompareTag("Finish") && timerRunning)
        {
            timerRunning = false;
            if (timer < bestTime)
            {
                bestTime = timer;
                PlayerPrefs.SetFloat("BestTime", bestTime);
                PlayerPrefs.Save();
                bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
            }
        }
        if (other.CompareTag("Buy") && coins > 50f)
        {
            coins = coins - 50f;
            PlayerPrefs.SetFloat("Coins", coins);
            PlayerPrefs.Save();
            float currcoin = PlayerPrefs.GetFloat("Coins");
            coin.text = "Coins: " + currcoin.ToString("F2");
        }
    }
}