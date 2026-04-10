using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAuraChange : MonoBehaviour
{
    public Material redauramat;
    public GameObject redauratrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float getcoins = PlayerPrefs.GetFloat("Coins");
            if (getcoins > 50f)
            {
                redauratrigger.GetComponent<MeshRenderer>().material = redauramat;
            }
        }
    }
}
