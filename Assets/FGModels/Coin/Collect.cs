using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float getcoin = PlayerPrefs.GetFloat("Coins");
            PlayerPrefs.SetFloat("Coins", getcoin + 50f);
            PlayerPrefs.Save();
            float currentcoin = PlayerPrefs.GetFloat("Coins");
            coin.text = "Coins: " + currentcoin.ToString("F2");
            Destroy(gameObject);
        }
    }
}
