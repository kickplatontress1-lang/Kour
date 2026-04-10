using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    //Время до взрыва
    [SerializeField] float explosionDelay = 5f;
    //Радиус поражения(расттояние от бомбы на котором игрока будет отталкивать)
    [SerializeField] float explosionRadius = 10f;
    //Сила взрыва(как сильно будет отталкивать игрока)
    [SerializeField] float explosionForce = 700f;
    //Ссылка на эффект взрыва
    [SerializeField] GameObject explosion;
    //Ссылка на префаб канваса
    [SerializeField] GameObject timerUIPrefab;
    //Объект для клонирования Canvas
    GameObject timerUI;
    //Ссылка на текст таймера
    TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        // Создаем UI над снарядом
        timerUI = Instantiate(timerUIPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        // отцепляем от снаряда
        timerUI.transform.SetParent(null);
        //Находим текст внутри Canvas и записываем его в переменную
        timerText = timerUI.GetComponentInChildren<TextMeshProUGUI>();
        explosionDelay = Random. Range (1, explosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        explosionDelay -= Time.deltaTime;     

        if (explosionDelay <= 0f)
        {
            Explode();
        }
        timerUI.transform.position = transform.position + Vector3.up * 1.5f;
        timerUI.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        timerText.text = explosionDelay.ToString("F1");
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var hit in colliders)
        {
            if (hit.CompareTag("Player") && hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Instantiate(explosion, transform.position, transform.rotation);        
        Destroy(gameObject);
        Destroy(timerUI);
    }
}
