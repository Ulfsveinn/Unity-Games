using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG;//corpo rigido do player
    public float jumpForce = 6f;//força do pulo
    public float gravityModifier = 1f;//gravidade do jogo
    public bool isOnGround = true;//verifica se está no chão
    // Start is called before the first frame update
    void Start()
    {
        playerRG = GetComponent<Rigidbody>();// Obtém o componente Rigidbody do jogador (serve para controlar o comportamento físico do jogador)
        Physics.gravity *= gravityModifier;//multiplica o valor da gravidade em cena
    }

    // Update is called once per frame
    void Update()
    {
        float space = Input.GetAxis("Jump");// Captura o valor do eixo de input para o botão de pulo
        // Verifica se o botão de pulo foi pressionado, se o jogador está no chão e verifica se o jogo não acabou
        if (space!=0&&isOnGround&&!GameController.gameOver)
        {
            playerRG.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);/*Aplica uma força que impulsiona o jogador para cima, com uma intensidade determinada pelo valor de jumpForce. 
                                                                       * Esta força é aplicada instantaneamente, usando Impulse como método de aplicação da força.*/
            isOnGround = false;//Define isOnGround como falso para indicar que o jogador não está mais no chão.
        }
    }
    private void OnCollisionEnter(Collision collision)// Quando ocorre uma colisão:
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;//Define isOnGround como verdadeiro para indicar que o jogador está no chão.
        } if (collision.gameObject.CompareTag("Obstacles")){
            GameController.gameOver = true;
        }
    }
          
       
    
}
