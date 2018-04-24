
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private static readonly Spawner uniqueInstance = new Spawner();
    private GameState gameState;
    private Phase phase;
    float spawnrate = 3;
    float nextspawn = 3;
    float nextspawn2 = 5;
    float spawnrate2 = 6;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    bool left;
    int counter = 0;
    int TECount = 0;
    int maxE = 10;
    float time;
    float speed = 1f / 30f;
    int health = 5;
    public bool defeatable = false;
    static bool moveable = true;

    private Spawner() { 
}

    public void Start()
    {

    }

    public void Awake()
    {
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
        if (transform.position.y > 6)
        {
            transform.Translate(0, -speed, 0);
        }
        else {
            float dy = transform.position.y - 6;
            transform.Translate(0, -dy, 0);
        }

        if (moveable)
        {
            Move();
        }
        if (health == 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        if(defeatable)
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SpawnerAction");
    }

    public void Move()
    {
        float dx = speed * phase.getPhase() * (left?-1:1);
        if (GameState.dead)
            dx = 0;
        transform.Translate(dx, 0, 0);

        float maxWid = 12f;
        if (transform.position.x > maxWid || transform.position.x < -maxWid)
        {
            left = !left;
        }



    } 

    public void prepareFire()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SpawnerAction");
    }

    public GameObject Fire(int p)
    {
        //print("success");
        if(GameState.dead )
        {
            return null;
        }

        if (p == 1)
        {
            if (gameState.getTime() > nextspawn && (phase.getCounter() % 4) != 0)
            {
             
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Spawner");
                return Instantiate(enemy, transform.position + new Vector3(0, -3), Quaternion.identity);
            }

        }
        if(p >= 2)
        {
            if (gameState.getTime() > nextspawn && (phase.getCounter() % 4) != 0)
            {
                
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Spawner");
                return Instantiate(enemy, transform.position + new Vector3(0, -3), Quaternion.identity);
            }
            if (gameState.getTime() > nextspawn && (phase.getCounter() % 4) == 0)
            {
                
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Spawner");
                return Instantiate(enemy2, transform.position + new Vector3(0, -1), Quaternion.identity);
            }
        }
        return null;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Destroy(other.gameObject);
            if (defeatable)
            {
                health -= 1;
                defeatable = false;
            }
        }
    }

    //Code for the singleton pattern

    public static Spawner getFactory()
    {
        //Keyword lock behaves similarly to java's synchronized keyword
        lock (uniqueInstance)
        {
            /*if (uniqueInstance == null)
                uniqueInstance = GameObject.Find("Spawner").GetComponent<Spawner>();*/
            return uniqueInstance;
        }
    }

}
