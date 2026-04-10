using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour
{
    // Start is called before the first frame update
    float defaultGravity = -9.81f; 
    bool isInZone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInZone && Input.GetKeyDown(KeyCode.G)) 
        {
            Physics.gravity = new Vector3(0, -Physics.gravity.y, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
            Physics.gravity = new Vector3(0, defaultGravity, 0);
        }
    }
}
