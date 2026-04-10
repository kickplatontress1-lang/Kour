using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    Vector3 currentCheckpoint;
    [SerializeField] float fallPoint = -20f;
    public Lava lava;
    // Start is called before the first frame update
    void Start()
    {
        currentCheckpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < fallPoint)
        {
            Respawn();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            currentCheckpoint = other.transform.position;
        }
    }
    public void Respawn()
    {
        transform.position = currentCheckpoint;
        lava.StopLava();
    }
}