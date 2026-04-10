using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] float growthSpeed = 0.8f;
    Vector3 startScale, startPosition;
    //Ссылка на скрипт PlayerRespawn
    PlayerRespawn respawn;
    bool isRising = false;
    void Start()
    {
        startScale = transform.localScale;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRising)
        {
            // Обновляем scale
            transform.localScale += new Vector3(0f, growthSpeed * Time.deltaTime, 0f);
            // Сдвигаем объект вверх на половину изменения высоты,
            // чтобы низ оставался на месте
            transform.position += new Vector3(0f, growthSpeed * Time.deltaTime/ 2f, 0f);
        }  
    }
    public void StartLava()
    {
        isRising = true;
    }
    public void StopLava()
    {
        isRising = false;
        transform.localScale = startScale;
        transform.position = startPosition;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var respawn = collision.gameObject.GetComponent<PlayerRespawn>();
            respawn.Respawn();
            StopLava();
        }
    }
}