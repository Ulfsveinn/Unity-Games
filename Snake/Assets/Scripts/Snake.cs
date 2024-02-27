using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    spawnFood spawnfood;
    //Comeu ou n
    bool eat = false;
    //Direção que a cobra vai se movimentar
    Vector2 dir = Vector2.right;
    //Tail Prefab
    public GameObject TailPrefab;
    //Tail
    List<Transform> tail= new List<Transform>();
    void Start()
    {
        spawnfood = FindAnyObjectByType<spawnFood>();
        InvokeRepeating("Move",1f,1f); 
    }

    // Update is called once per frame
    void Update()
    {
        //Controles do jogo
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            dir =Vector2.up;
        }
        else if((Input.GetKey(KeyCode.DownArrow)))
        { dir = Vector2.down; }
    }
    void Move()
    {
        transform.Translate(dir);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("food"))
        {
            eat=true;
            Destroy(coll.gameObject);
            if(eat)
            {
                spawnfood.comida();
            }
        }
        else
        {
            //dead, fim de jogo
            Debug.Log("DEAD!");
        }
    }

}
