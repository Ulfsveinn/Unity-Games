using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moveLeft : MonoBehaviour
{
    private float speed = 10f; // Velocidade do movimento para a esquerda
    // Método chamado antes do primeiro frame
    void Start()
    {
        // Nenhuma inicialização necessária neste caso
    }
    // Método chamado a cada frame
    void Update()
    {
        // Verifica se o jogo não acabou
        if (!GameController.gameOver)
        {
            // Move o objeto para a esquerda com base na velocidade definida
            // A multiplicação por Time.deltaTime garante que o movimento seja suave e independente da taxa de quadros
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
