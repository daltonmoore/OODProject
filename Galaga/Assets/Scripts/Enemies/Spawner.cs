
using System;
using UnityEngine;

public class Spawner : MonoBehaviour, Enemy
{
    private static Spawner instance;
    private GameState gameState;
    private Phase phase;
    float spawnrate = 3;
    float nextspawn = 3;
    float nextspawn2 = 5;
    float spawnrate2 = 6;
    public GameObject enemy;
    public GameObject enemy2;
    int c1= 0, c2 = 0;
    int counter = 0;
    int TECount = 0;
    int maxE = 10;
    float time;
    float speed = 1f / 30f;
    static bool defeatable = false;
    static bool moveable = true;

    public void Start()
    {

    }

    public void Awake()
    {
        instance = GameObject.Find("Spawner").GetComponent<Spawner>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        phase = GameObject.Find("Phase").GetComponent<Phase>();
    }

    public void pauseSpawner()
    {
        moveable = false;
        gameObject.transform.position = Vector2.MoveTowards(transform.position, 
                                    new Vector3(0, 7), speed * Time.deltaTime);
    }

    public void unpauseSpawner()
    {
        moveable = true;
    }

    public void Update()
    {
        if (Time.time < 3)
        {
            transform.Translate(0, -speed, 0);
        }

        if (moveable)
        {
            Move();
        }

    }

    public void Move()
    {
        c1++;
        if (c1 < 300 && c2 == 0)
        {
            transform.Translate(speed, 0, 0);
        }
        else
        {
            c2++;
            transform.Translate(-speed, 0, 0);
        }
        if (c2 > 600)
        {
            c1 = -300;
            c2 = 0;
        }
    } 

    public void prepareFire()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SpawnerAction");
    }

    public void Fire()
    {
        if (Time.time > nextspawn && (phase.getCounter() % 4) != 0)
        {
            Instantiate(enemy, transform.position + new Vector3(0, -3), Quaternion.identity);
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Spawner");
        }
        if (Time.time > nextspawn && (phase.getCounter() % 4) == 0)
        {
            Instantiate(enemy2, transform.position + new Vector3(0, -1), Quaternion.identity);
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Spawner");
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Destroy(other.gameObject);
            if(defeatable)
                Destroy(gameObject);
        }
    }

    //Code for the singleton pattern

    public static Spawner getFactory()
    {
        //Keyword lock behaves similarly to java's synchronized keyword
        lock (instance)
        {
            if (instance == null)
                instance = GameObject.Find("Spawner").GetComponent<Spawner>();
            return instance;
        }
    }

}
