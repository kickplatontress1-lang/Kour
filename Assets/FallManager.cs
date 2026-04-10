using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] plates;
    [SerializeField] int platesCount;
    [SerializeField] int platesLength;
    void Start()
    {
        for (var i = 0; i < plates.Length; i += plates.Length / platesLength)
        {
            var x = Random.Range(i, i + platesCount);
            plates[x].gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
