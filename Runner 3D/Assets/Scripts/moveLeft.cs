using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private float leftBound = -10; // Limite à esquerda onde o objeto será destruído
    void Start()
    {
    }

    // Método chamado a cada frame
    void Update()
    {
        // Verifica se o jogo não acabou
        if (!GameController.gameOver)
        {
            // Move o objeto para a esquerda multiplicando pela velocidade do jogo e o tempo entre frames
            transform.Translate(Vector3.left * GameController.speed * Time.deltaTime);
            // Se o objeto ultrapassar o limite à esquerda e tiver a tag "Obstacles"
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
            {
                Destroy(gameObject); // Destroi o objeto
            }
        }
    }
}
