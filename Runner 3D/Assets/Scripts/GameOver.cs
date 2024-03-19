using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public Text score;
    public Text highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        GameController.saveData();
        score.text = "  Player: " + GameController.PlayerName+ " ---- Score: " + GameController.score.ToString();
        highScore.text = "HighScorePlayer: " + GameController.nameHighScore + " ---- HighScore: " + GameController.highScoreGC.ToString();
        Invoke("Menu", 5f);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
