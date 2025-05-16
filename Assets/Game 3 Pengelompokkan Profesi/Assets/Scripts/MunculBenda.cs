using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculBenda : MonoBehaviour
{
    public float jeda = 1f;
    float timer;
    public GameObject[] benda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > jeda)
        {
            int random = Random.Range(0, benda.Length);
            Instantiate (benda [random], transform.position,
            transform.rotation);
            timer = 0;
        }
    }
}