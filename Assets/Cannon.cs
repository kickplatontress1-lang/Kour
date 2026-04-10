using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    //Ссылка на префаб нашей бомбы
    [SerializeField] GameObject projectilePrefab;
    //Точка в которой будет появляться бомба
    [SerializeField] Transform firePoint;
    //Время между выстрелами
    [SerializeField] float fireInterval = 3f;
    //Сила выстрела
    [SerializeField] float launchForce = 500f;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireInterval);
    }
    void Fire()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * launchForce);
    }
}
