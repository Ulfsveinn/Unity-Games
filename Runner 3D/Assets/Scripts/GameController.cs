using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static float speed = 10f;//Controlar a velocidade do jogo
    public static float timetoSpawn=3f;//Controlar o tempo de criar novos obst�culos
    public static float score=0f;//Pontua��o do jogo
    public static bool gameOver = false;//Controla o estado do jogo
    public static string PlayerName;
    public static string nameHighScore;
    public static float highScoreGC = 0f;
    public TextMeshProUGUI scoreText;

    public static void loadData(){
        GameController.highScoreGC = PlayerPrefs.GetFloat("HighScore",0f);
        GameController.nameHighScore = PlayerPrefs.GetString("HighScoreName","Player");
    }
    public static void saveData(){
        if (GameController.score > GameController.highScoreGC){
            PlayerPrefs.SetFloat("HighScore", GameController.score);
            PlayerPrefs.SetString("HighScoreName", GameController.PlayerName);
            GameController.highScoreGC=GameController.score;
            GameController.nameHighScore = GameController.PlayerName;
            PlayerPrefs.Save();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        GameController.loadData();
        GameController.speed = 10f;
        GameController.timetoSpawn = 3f;
        GameController.score = 0f;
        GameController.gameOver = false;
        // Invoca repetidamente o m�todo ChangeDificult ap�s 1 segundo, com um intervalo de 5 segundos entre as invoca��es
        InvokeRepeating("ChangeDificult", 1f, 5f);
        // Invoca repetidamente o m�todo ScoreTimer ap�s 0.5 segundos, com um intervalo de 0.5 segundos entre as invoca��es
        InvokeRepeating("ScoreTimer", 0.5f,0.5f);
        }
    //Controlar a dificuldade do jogo
    void ChangeDificult()
    {
        if (!GameController.gameOver)
        {
        GameController.speed += 1;// Aumenta a velocidade do jogo em 1 
        // Limita o tempo de spawn de novos obst�culos entre 1.5 e 5 segundos
        GameController.timetoSpawn = Mathf.Clamp(GameController.timetoSpawn=0.5f,1.5f,5f);
        }
    }
    void Update()
    {
        scoreText.text = "Score: " + GameController.score;// Atualiza o texto da pontua��o
    }
    // Controla o temporizador de pontua��o
    void ScoreTimer()
    {
        // Incrementa a pontua��o do jogo em 1 se o jogo n�o acabou
        if (!GameController.gameOver){
            GameController.score += 1;
        }
    }
}
