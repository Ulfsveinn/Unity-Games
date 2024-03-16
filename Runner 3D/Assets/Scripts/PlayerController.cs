using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG;//corpo rigido do player
    public float jumpForce = 6f;//for�a do pulo
    public float gravityModifier = 1f;//gravidade do jogo
    public bool isOnGround = true;//verifica se est� no ch�o
    // Start is called before the first frame update
    void Start()
    {
        playerRG = GetComponent<Rigidbody>();// Obt�m o componente Rigidbody do jogador (serve para controlar o comportamento f�sico do jogador)
        Physics.gravity *= gravityModifier;//multiplica o valor da gravidade em cena
    }

    // Update is called once per frame
    void Update()
    {
        float space = Input.GetAxis("Jump");// Captura o valor do eixo de input para o bot�o de pulo
        // Verifica se o bot�o de pulo foi pressionado, se o jogador est� no ch�o e verifica se o jogo n�o acabou
        if (space!=0&&isOnGround&&!GameController.gameOver)
        {
            playerRG.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);/*Aplica uma for�a que impulsiona o jogador para cima, com uma intensidade determinada pelo valor de jumpForce. 
                                                                       * Esta for�a � aplicada instantaneamente, usando Impulse como m�todo de aplica��o da for�a.*/
            isOnGround = false;//Define isOnGround como falso para indicar que o jogador n�o est� mais no ch�o.
        }
    }
    private void OnCollisionEnter(Collision collision)// Quando ocorre uma colis�o:
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;//Define isOnGround como verdadeiro para indicar que o jogador est� no ch�o.
        } if (collision.gameObject.CompareTag("Obstacles")){
            GameController.gameOver = true;
        }
    }
          
       
    
}
