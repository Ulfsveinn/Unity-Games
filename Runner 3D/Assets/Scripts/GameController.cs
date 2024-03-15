using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public static float speed = 10f;//Controlar a velocidade do jogo
    public static float timetoSpawn=3f;//Controlar o tempo de criar novos obstáculos
    public static float score=0f;//Pontuação do jogo
    public static bool gameOver = false;//Controla o estado do jogo
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
      
    }  
    //Controlar a dificuldade do jogo
}
