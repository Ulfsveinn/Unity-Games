using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moveLeft : MonoBehaviour
{
    private float leftBound = -10;
   // private float speed = 10f; // Velocidade do movimento para a esquerda
    void Start()
    {
        // Nenhuma inicializa��o necess�ria neste caso
    }
    // M�todo chamado a cada frame
    void Update()
    {
        // Verifica se o jogo n�o acabou
        if (!GameController.gameOver)
        {
            transform.Translate(Vector3.left * GameController.speed * Time.deltaTime);
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
            {
                Destroy(gameObject);
            }
        }
    }
}
