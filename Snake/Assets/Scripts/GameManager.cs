using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreGame;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
    }
    //Método para atualizar o score
    void UpdateScoreText()
    {
        scoreGame.text = "Score: " + score;
    }

    // Método para aumentar o score
    public void IncreaseScore(int soma)
    {
        score += soma;
        UpdateScoreText(); // Atualiza o texto do score sempre que a pontuação é alterada.
    }
}
