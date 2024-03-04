using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG;//corpo rigido do player
    public float jumpForce = 10f;//for�a do pulo
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
        if(Input.GetKeyDown(KeyCode.Space)&&isOnGround)// Se a tecla de espa�o for pressionada e o jogador estiver no ch�o:
        {
            playerRG.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);/*Aplica uma for�a que impulsiona o jogador para cima, com uma intensidade determinada pelo valor de jumpForce. 
                                                                       * Esta for�a � aplicada instantaneamente, usando Impulse como m�todo de aplica��o da for�a.*/
            isOnGround = false;//Define isOnGround como falso para indicar que o jogador n�o est� mais no ch�o.
        }
    }
    private void OnCollisionEnter(Collision collision)// Quando ocorre uma colis�o:
    {
        isOnGround = true;//Define isOnGround como verdadeiro para indicar que o jogador est� no ch�o.
    }
}
