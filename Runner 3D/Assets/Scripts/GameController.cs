using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public static float speed = 10f;//Controlar a velocidade do jogo
    public static float timetoSpawn=3f;//Controlar o tempo de criar novos obstáculos
    public static float score=0f;//Pontuação do jogo
    public static bool gameOver = false;//Controla o estado do jogo
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        
        GameController.speed = 10f;
        GameController.timetoSpawn = 3f;
        GameController.score = 0f;
        GameController.gameOver = false;
        // Invoca repetidamente o método ChangeDificult após 1 segundo, com um intervalo de 5 segundos entre as invocações
        InvokeRepeating("ChangeDificult", 1f, 5f);
        InvokeRepeating("ScoreTimer", 0.5f,0.5f);
        }
    //Controlar a dificuldade do jogo
    void ChangeDificult()
    {
        GameController.speed += 1;// Aumenta a velocidade do jogo em 1 
        // Limita o tempo de spawn de novos obstáculos entre 1.5 e 5 segundos
        GameController.timetoSpawn = Mathf.Clamp(GameController.timetoSpawn=0.5f,1.5f,5f);
       
    }
    void Update()
    {
        scoreText.text = "Score: " + GameController.score;
    }
    void ScoreTimer()
    {
        if (!GameController.gameOver){
            GameController.score += 1;// Incrementa a pontuação do jogo em 1
        }
    }
}
