using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG; // Corpo r�gido do jogador
    private Animator PlayerAnima; // Controla a anima��o do jogador
    public float jumpForce; // For�a do pulo do jogador
    public float gravityModifier; // Modificador de gravidade do jogo
    public bool isOnGround = true; // Verifica se o jogador est� no ch�o
    public ParticleSystem explosion; // Part�culas de explos�o
    public ParticleSystem dirt; // Part�culas de poeira quando o jogador est� no ch�o
    private AudioSource PlayerAudio;//toca os sons do player jump e hit
    public AudioClip JumpClip;
    public AudioClip CrashClip;

    // Start is called before the first frame update
    void Start()
    {

        PlayerAudio = GetComponent<AudioSource>();
        PlayerAnima = GetComponent<Animator>(); // Obt�m o componente Animator do jogador
        playerRG = GetComponent<Rigidbody>(); // Obt�m o componente Rigidbody do jogador (serve para controlar o comportamento f�sico do jogador)
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
        Debug.Log($"Initial Gravity: {Physics.gravity}");
    }

    // Update is called once per frame
    void Update()
    {
        float space = Input.GetAxis("Jump"); // Captura o valor do eixo de input para o bot�o de pulo
        // Verifica se o bot�o de pulo foi pressionado, se o jogador est� no ch�o e se o jogo n�o acabou
        if (space != 0 && isOnGround && !GameController.gameOver)
        {
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            PlayerAnima.SetTrigger("Jump_trig"); // Ativa a anima��o de pulo
            PlayerAudio.PlayOneShot(JumpClip);
            isOnGround = false; // Define isOnGround como falso para indicar que o jogador n�o est� mais no ch�o.
            dirt.Stop(); // Para a reprodu��o das part�culas de poeira
        }
    }

    // Quando ocorre uma colis�o
    private void OnCollisionEnter(Collision collision)
    {
        // Se a colis�o ocorrer com o objeto com a tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Define isOnGround como verdadeiro para indicar que o jogador est� no ch�o.
            dirt.Play(); // Inicia a reprodu��o das part�culas de poeira
        }
        // Se a colis�o ocorrer com o objeto com a tag "Obstacles"
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            GameController.gameOver = true; // Define o sinalizador de game over como verdadeiro
            PlayerAnima.SetBool("Death_b", true); // Ativa a anima��o de morte
            PlayerAnima.SetInteger("DeathType_int", 1); // Define o tipo de morte (pode ser usado para diferentes anima��es de morte)
            explosion.Play(); // Reproduz as part�culas de explos�o
            dirt.Stop(); // Para a reprodu��o das part�culas de poeira
            PlayerAudio.PlayOneShot(CrashClip);
            Invoke("GameOver", 2f);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
