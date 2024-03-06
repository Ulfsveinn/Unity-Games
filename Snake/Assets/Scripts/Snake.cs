using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    GameManager gameManager;
    spawnFood spawnfood;
    static public float scoretual = 0f;
    //Comeu ou n
    bool eat = false;
    //Direção que a cobra vai se movimentar
    Vector2 dir = Vector2.zero;
    //Tail Prefab
    public GameObject TailPrefab;
    //Tail
   public List<Transform> tail = new List<Transform>();
    private float speed;
   public int comidascoletadas;
    bool direcaoHorizontal = false;
    bool direcaoVertical = false;   
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnfood = FindAnyObjectByType<spawnFood>();
        speed = 0.15f;
        StartCoroutine("NewMove");
    }
    // Update is called once per frame
    void Update()
    {
        //Controles do jogo
        if (!direcaoHorizontal)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
               
                direcaoVertical = false;
                dir = Vector2.right;
                direcaoHorizontal = true;
            }
        }
        if (!direcaoHorizontal)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direcaoVertical = false;
                dir = Vector2.left;
                direcaoHorizontal = true;
            }
        }
       if(!direcaoVertical)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direcaoHorizontal = false;
                dir = Vector2.up;
                direcaoVertical = true;
            }
        }
        if (!direcaoVertical)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direcaoHorizontal = false;
                dir = Vector2.down;
                direcaoVertical = true;
            }
        }
        Debug.Log(spawnfood.comidaParede);
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
            comidascoletadas++;
            Destroy(coll.gameObject);
            eat = true;
            gameManager.IncreaseScore(1);
           Snake.scoretual = gameManager.score;
            spawnfood.comida();
            if (comidascoletadas % 5 == 0)//a cada 5 comidas coletadas ele aumenta a velocidade
            {
                speed -= 0.2f;

            }
            if (speed < 0.1f)
            {
                speed = 0.1f;
            }
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

