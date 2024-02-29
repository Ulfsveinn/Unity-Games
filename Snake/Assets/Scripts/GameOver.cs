using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scorefinal;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        scorefinal.text = "Score: " + Snake.scoretual;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
