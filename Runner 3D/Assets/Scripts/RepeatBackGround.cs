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
        // Define a posição inicial como a posição atual do objeto
        startPosition = transform.position;
        // Calcula a metade da largura do collider do objeto
        RepeatWitdh = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se a posição atual do objeto está fora da tela à esquerda
        if (transform.position.x<startPosition.x - RepeatWitdh)
        {
            // Se estiver, define a posição do objeto de volta para a posição inicial
            transform.position=startPosition;
        }
    }
}
