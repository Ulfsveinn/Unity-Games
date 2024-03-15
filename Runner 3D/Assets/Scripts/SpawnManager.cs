using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;
    private Vector3 spawnPosition = new Vector3 (25f, 0.15f, 0f);
    private IEnumerator couroutine;
    //public float startDelay = 2f;
    //public float repeatRate = 2f;
    // Start is called before the first frame update
    void Start(){
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        couroutine = SpawnObstacles();
        StartCoroutine(couroutine);
    }

    // Update is called once per frame
    void Update(){
        
    }
    IEnumerator SpawnObstacles(){
        while (true)
        {
            CreateObstacle();
            yield return new WaitForSeconds(3f);//interrompa a execução da funçaõ dps de 3s ira voltar a executala.
        }
    }
    void CreateObstacle(){
        GameObject obstacle = obstaclesPrefab[Random.Range(0,obstaclesPrefab.Length-1)];
        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
    }
}
