using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,30f);//destroi dps de 10s
    }
    // Update is called once per frame
    void Update()
    {
    }
}
