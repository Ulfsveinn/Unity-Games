using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject headPrefab;
    private bool start;
    public spawnFood spawnfood;
    private void Start()
    {
        spawnfood = gameObject.GetComponent<spawnFood>();   
    }
    void Update()
    {
       
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        start = true;
        spawnfood.StartsPawnFood();
        Instantiate(headPrefab, new Vector2(0f,0f), Quaternion.identity);
    }
}
