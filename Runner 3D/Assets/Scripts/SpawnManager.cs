using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab; // Array para armazenar diferentes prefabs de obstáculos
    private Vector3 spawnPosition = new Vector3(25f, 0.15f, 0f); // Posição inicial de spawn para os obstáculos
    private IEnumerator couroutine; // Coroutine para spawnar obstáculos
    // Start is called before the first frame update
    void Start()
    {
        // Inicializa a coroutine e começa a spawnar obstáculos
        couroutine = SpawnObstacles();
        StartCoroutine(couroutine);
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Speed: " + GameController.speed);
        //Debug.Log("Pontos: " + GameController.score);
    }
    // Coroutine para spawnar obstáculos repetidamente
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (!GameController.gameOver)
            {
                // Chama a função para criar e spawnar um obstáculo
                CreateObstacle();
            }
            // Aguarda o tempo determinado por GameController.timetoSpawn antes de spawnar o próximo obstáculo
            yield return new WaitForSeconds(GameController.timetoSpawn);
        }
    }
    void CreateObstacle()
    {
        // Seleciona aleatoriamente um prefab de obstáculo do array
        GameObject obstacle = obstaclesPrefab[Random.Range(0, obstaclesPrefab.Length)];
        // Instancia o obstáculo selecionado na posição de spawn com sua rotação padrão
        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
    }
}
