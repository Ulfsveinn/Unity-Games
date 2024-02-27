using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject headPrefab;
    private bool start;

    // Update is called once per frame
    void Update()
    {
       
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        start = true;
        Instantiate(headPrefab, new Vector2(0f,0f), Quaternion.identity);
    }
}
