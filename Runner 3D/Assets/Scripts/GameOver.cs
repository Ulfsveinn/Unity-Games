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
        score.text = "Score: " + GameController.score.ToString();
        highScore.text = "Player: " + " HighScore: " + GameController.score;
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
