using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFood : MonoBehaviour
{
    //Definir os limites do spawn de comidas
    public Transform BorderTop;
    public Transform BorderLeft;
    public Transform BorderRight;
    public Transform BorderBot;
    //Prefab da comida
    public GameObject food;
    bool temcomida = false;
    GameObject atualcomida;
    void Start()
    {
         Spawn();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Spawn()
    {
        if(!temcomida)
        {
            //defini local que a comida sera criada
            int x = (int)Random.Range(BorderLeft.position.x, BorderRight.position.x);//cria um numero Random entre as duas bordas na Horizontal(x)
            int y = (int)Random.Range(BorderTop.position.y, BorderBot.position.y);//cria um numero Random entre as duas bordas na vertical(y)
            Vector2 spawnposition = new Vector2(x, y);
           atualcomida=Instantiate(food, spawnposition, Quaternion.identity);
            temcomida = true;
        }
    }
    public void comida()
    {
        if (atualcomida != null)
        {
            temcomida = false;
            Spawn();
        }
    }
    public void StartsPawnFood()
    {
        Spawn();
    }
}
