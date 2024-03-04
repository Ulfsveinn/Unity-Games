using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    GameController gameController;
    GameManager gameManager;
    spawnFood spawnfood;
    static public float scoretual = 0f;
    //Comeu ou n
    bool eat = false;
    //Dire��o que a cobra vai se movimentar
    Vector2 dir = Vector2.right;
    //Tail Prefab
    public GameObject TailPrefab;
    //Tail
    List<Transform> tail = new List<Transform>();
    private float speed;
    private float startTime;
    int comidascoletadas;
    void Start()
    {
        gameController = GetComponent<GameController>();
        gameManager = FindObjectOfType<GameManager>();
        spawnfood = FindAnyObjectByType<spawnFood>();
        speed = 0.15f;
        startTime = Time.time;
        StartCoroutine("NewMove");
        Debug.Log(comidascoletadas);
        Debug.Log(speed);
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
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        else if ((Input.GetKey(KeyCode.DownArrow)))
        { dir = Vector2.down; }
    }
    void Move()
    {
        Vector2 v = transform.position;//salvando a coordenada atual
        //movimentei a head da snake
        transform.Translate(dir);
        //tail - cauda
        if (eat)
        {
            //cria a cauda
            GameObject g = (GameObject)Instantiate(TailPrefab, v, Quaternion.identity);
            //defino o elemento como inicio da cauda
            tail.Insert(0, g.transform);
            eat = false;
        }
        else if (tail.Count > 0)
        {
            //muda a coordenada de tela do elemento
            tail[tail.Count - 1].position = v;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }
      
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
     
        if (coll.name.StartsWith("food"))
        {
            //comidascoletadas++;
            Destroy(coll.gameObject);
            eat = true;
            gameManager.IncreaseScore(1);
           Snake.scoretual = gameManager.score;
            spawnfood.comida();
            //if(comidascoletadas % 5==0)
            //{
            //    speed -= 0.05f;
                
            //}
            //if (speed < 0.1f)
            //{
            //    speed = 0.1f;
            //}
        }
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
        }
    private IEnumerator NewMove()
    {
        while(true)
        {
            Move();
            yield return new WaitForSeconds(speed);
        }
    }
    }

