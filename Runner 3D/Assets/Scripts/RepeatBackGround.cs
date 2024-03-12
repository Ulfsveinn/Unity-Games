using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private Vector3 startPosition;//posição inicial do fundo
    private float RepeatWitdh;//Largura da tela
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        RepeatWitdh = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<startPosition.x - RepeatWitdh)
        {
            transform.position=startPosition;
        }
    }
}
