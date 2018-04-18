using UnityEngine;

public class GameState : MonoBehaviour {

    public static GameObject player;
    public static GameState instance;
    public static Spawner spawner;
	public static int SCORE = 0;
	public static int LIVES = 3;
	public static float TIME_ALIVE = 0;
    public bool gameStart = false;
    public bool gameOver = false;
    public static double respawnTimer;
    public static bool dead;
    public static int enemyCount = 0;
    int phase = 1;
    int maxE = 10;
    int killCount = 0;
    float nextspawn = 3;
    float nextspawn2 = 5;

    public float getTime()
    {
        return TIME_ALIVE;
    }

    public void printPhase()
    {
        print("Phase " + phase);
        print("Max enemy count: " + maxE);
    }

    public int getPhase()
    {
        return phase;
    }

    public void addEC()
    {
        enemyCount++;
        print(enemyCount);
    }

    public int getEC()
    {
        return enemyCount;
    }
    
    public void addKC()
    {
        killCount++;
    }

    public int getKC()
    {
        return killCount;
    }

    public void spawn()
    {
        if (Time.time > nextspawn - .5)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SpawnerAction");
        }

    }

    private void Awake()
    {
        spawner = Spawner.getFactory();
        player = Resources.Load("Player") as GameObject;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start () {
        
	}

    /*Handles player death. If Lives reaches 0, the game is over.
     * Argument o is the player game object passed from the player class.*/
    public void die(GameObject o)
    {
        if (LIVES > 0)
        {
            LIVES--;
            dead = true;
            respawnTimer = 3;
            Destroy(o);
        }
        else
            GameOver();
    }

	void Update () {

        if (dead == true && LIVES > 0)
        {
            respawnTimer -= Time.deltaTime;
            if(respawnTimer < 0)
            {
                Instantiate( player, player.transform.position, Quaternion.identity);
                dead = false;
            }
        }
        if(!dead)
		    TIME_ALIVE = TIME_ALIVE + Time.deltaTime; // Maybe this can be used somewhere?
	}

    void GameOver()
    {
        gameOver = true;
        print("Game Over");
    }

}
