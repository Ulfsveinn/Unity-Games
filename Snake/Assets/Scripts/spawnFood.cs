using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawnFood : MonoBehaviour
{
    // Definir os limites do spawn de comidas
    public Transform BorderTop2; // Limite superior 2
    public Transform BorderLeft2; // Limite esquerdo 2
    public Transform BorderRight2; // Limite direito 2
    public Transform BorderBot2; // Limite inferior 2
    public Transform BorderTop1; // Limite superior 1
    public Transform BorderLeft1; // Limite esquerdo 1
    public Transform BorderRight1; // Limite direito 1
    public Transform BorderBot1; // Limite inferior 1

    public GameObject wall; // Parede
    public GameObject wall2; // Parede 2

    public GameObject food; // Prefab da comida
    GameObject atualcomida; // Comida atual
    public Boolean borda = false;
    public int comidaParede=0;
    Snake snake;

    void Start()
    {
       snake = GetComponent<Snake>();
        // Spawn da comida inicial
        Spawn();
        // Ativar a parede
        wall.SetActive(true);
        wall2.SetActive(false);
        borda = false;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (comidaParede>50)
        {
           Paredes();
        }
    }
    // Método para spawn da comida
    void Spawn()
    {
        if (atualcomida == null)
        {
            // Definir uma posição aleatória para a comida dentro dos limites
            if (!borda)
            {
                int x1 = (int)Random.Range(-10.06f, 10.12f);
                int y1 = (int)Random.Range(10.15f, -10.11f);
                Vector2 spawnposition = new Vector2(x1, y1);


                // Verificar se a posição de spawn não está dentro do corpo da cobra
                if (!dentroDoCorpo(spawnposition))
                {
                    // Instanciar a comida na posição gerada
                    atualcomida = Instantiate(food, spawnposition, Quaternion.identity);
                    comidaParede++;
                }
            }else if (borda)
            {
                int x2 = (int)Random.Range(-33f,32.98f);//cria um numero Random entre as duas bordas na Horizontal(x)
                int y2 = (int)Random.Range(23.97f,-24f);//cria um numero Random entre as duas bordas na vertical(y)

                Vector2 spawnposition = new Vector2(x2, y2);
                if (!dentroDoCorpo(spawnposition))
                {
                    // Instanciar a comida na posição gerada
                    atualcomida = Instantiate(food, spawnposition, Quaternion.identity);
                }
            }
        }
    }
    // Método para resetar a comida quando coletada
    public void comida()
    {
        // Resetar a comida atual
        atualcomida = null;
        // Spawn de uma nova comida
        Spawn();
    }
    // Método para iniciar o spawn da comida
    public void StartsPawnFood()
    {
        Spawn();
    }
    // Método para verificar se a posição está dentro do corpo da cobra
    bool dentroDoCorpo(Vector2 position)
    {
        return false; // Temporariamente retorna falso, você precisa implementar essa função
    }
    // Métodos para ativar e desativar as paredes
  public void Paredes()
    {
        borda = true;
        wall2.SetActive(true);
        wall.SetActive(false);
        }
    }
