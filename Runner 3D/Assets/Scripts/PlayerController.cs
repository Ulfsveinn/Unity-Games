using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG; // Corpo rígido do jogador
    private Animator PlayerAnima; // Controla a animação do jogador
    public float jumpForce; // Força do pulo do jogador
    public float gravityModifier; // Modificador de gravidade do jogo
    public bool isOnGround = true; // Verifica se o jogador está no chão
    public ParticleSystem explosion; // Partículas de explosão
    public ParticleSystem dirt; // Partículas de poeira quando o jogador está no chão
    private AudioSource PlayerAudio;//toca os sons do player jump e hit
    public AudioClip JumpClip;
    public AudioClip CrashClip;

    // Start is called before the first frame update
    void Start()
    {

        PlayerAudio = GetComponent<AudioSource>();
        PlayerAnima = GetComponent<Animator>(); // Obtém o componente Animator do jogador
        playerRG = GetComponent<Rigidbody>(); // Obtém o componente Rigidbody do jogador (serve para controlar o comportamento físico do jogador)
        Physics.gravity = new Vector3(0, -9.81f * gravityModifier, 0);
        Debug.Log($"Initial Gravity: {Physics.gravity}");
    }

    // Update is called once per frame
    void Update()
    {
        float space = Input.GetAxis("Jump"); // Captura o valor do eixo de input para o botão de pulo
        // Verifica se o botão de pulo foi pressionado, se o jogador está no chão e se o jogo não acabou
        if (space != 0 && isOnGround && !GameController.gameOver)
        {
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            PlayerAnima.SetTrigger("Jump_trig"); // Ativa a animação de pulo
            PlayerAudio.PlayOneShot(JumpClip);
            isOnGround = false; // Define isOnGround como falso para indicar que o jogador não está mais no chão.
            dirt.Stop(); // Para a reprodução das partículas de poeira
        }
    }

    // Quando ocorre uma colisão
    private void OnCollisionEnter(Collision collision)
    {
        // Se a colisão ocorrer com o objeto com a tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Define isOnGround como verdadeiro para indicar que o jogador está no chão.
            dirt.Play(); // Inicia a reprodução das partículas de poeira
        }
        // Se a colisão ocorrer com o objeto com a tag "Obstacles"
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            GameController.gameOver = true; // Define o sinalizador de game over como verdadeiro
            PlayerAnima.SetBool("Death_b", true); // Ativa a animação de morte
            PlayerAnima.SetInteger("DeathType_int", 1); // Define o tipo de morte (pode ser usado para diferentes animações de morte)
            explosion.Play(); // Reproduz as partículas de explosão
            dirt.Stop(); // Para a reprodução das partículas de poeira
            PlayerAudio.PlayOneShot(CrashClip);
            Invoke("GameOver", 2f);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
