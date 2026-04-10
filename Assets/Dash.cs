using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] float force = 20f; 
    //Это направление, в котором игрок должен отлететь.
    private Vector3 hitDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                //Это направление, откуда пришёл удар. То есть куда толкнуть игрока обратно.
                hitDir = contact.normal;
                //Берём физику игрока (Rigidbody) и толкаем его назад с заданной силой.
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Impulse);
                //Говорим: "Всё, хватит! Мы уже толкнули игрока, можно закончить цикл."
                return;
            }
        }
    }
}
