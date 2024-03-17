using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private float leftBound = -10; // Limite � esquerda onde o objeto ser� destru�do
    void Start()
    {
    }

    // M�todo chamado a cada frame
    void Update()
    {
        // Verifica se o jogo n�o acabou
        if (!GameController.gameOver)
        {
            // Move o objeto para a esquerda multiplicando pela velocidade do jogo e o tempo entre frames
            transform.Translate(Vector3.left * GameController.speed * Time.deltaTime);
            // Se o objeto ultrapassar o limite � esquerda e tiver a tag "Obstacles"
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
            {
                Destroy(gameObject); // Destroi o objeto
            }
        }
    }
}
