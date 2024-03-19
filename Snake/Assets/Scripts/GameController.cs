using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameManager gameManager;
    public GameObject headPrefab;
    public spawnFood spawnfood;
    
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        spawnfood = gameObject.GetComponent<spawnFood>();   
    }
    void Update()
    {
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        gameManager.score = 0;
        spawnfood.StartsPawnFood();
        Instantiate(headPrefab, new Vector2(0f,0f), Quaternion.identity);
    }
    public void restart()
    {
        StartGame();
    }
    public void gmmenu()
    {
        SceneManager.LoadScene(0);
    }
   }
