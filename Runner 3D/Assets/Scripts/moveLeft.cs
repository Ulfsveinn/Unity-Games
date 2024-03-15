using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moveLeft : MonoBehaviour
{
    private float speed = 10f; // Velocidade do movimento para a esquerda
    // M�todo chamado antes do primeiro frame
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
            // Move o objeto para a esquerda com base na velocidade definida
            // A multiplica��o por Time.deltaTime garante que o movimento seja suave e independente da taxa de quadros
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
