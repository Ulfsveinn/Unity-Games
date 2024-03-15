using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;// Array para armazenar diferentes prefabs de obst�culos
    private Vector3 spawnPosition = new Vector3 (25f, 0.15f, 0f); // Posi��o inicial de spawn para os obst�culos
    private IEnumerator couroutine;// Coroutine para spawnar obst�culos
    //public float startDelay = 2f;
    //public float repeatRate = 2f;
    // Start is called before the first frame update
    void Start(){
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        // Inicializa a coroutine e come�a a spawnar obst�culos
        couroutine = SpawnObstacles();
        StartCoroutine(couroutine);
    }

    // Update is called once per frame
    void Update(){
        
    }
    // Coroutine para spawnar obst�culos repetidamente
    IEnumerator SpawnObstacles(){
        while (true)
        {
            if (!GameController.gameOver) {
                // Chama a fun��o para criar e spawnar um obst�culo
                CreateObstacle();
                // Aguarda 3 segundos antes de spawnar o pr�ximo obst�culo
                yield return new WaitForSeconds(3f);
            }
           
           
           
        }
    }
    void CreateObstacle(){
        // Seleciona aleatoriamente um prefab de obst�culo do array
        GameObject obstacle = obstaclesPrefab[Random.Range(0,obstaclesPrefab.Length-1)];
        // Instancia o obst�culo selecionado na posi��o de spawn com sua rota��o padr�o
        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
    }
}
