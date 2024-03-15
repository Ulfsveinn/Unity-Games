using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private Vector3 startPosition;//posi��o inicial do fundo
    private float RepeatWitdh;//Largura da tela
    // Start is called before the first frame update
    void Start()
    {
        // Define a posi��o inicial como a posi��o atual do objeto
        startPosition = transform.position;
        // Calcula a metade da largura do collider do objeto
        RepeatWitdh = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se a posi��o atual do objeto est� fora da tela � esquerda
        if (transform.position.x<startPosition.x - RepeatWitdh)
        {
            // Se estiver, define a posi��o do objeto de volta para a posi��o inicial
            transform.position=startPosition;
        }
    }
}
