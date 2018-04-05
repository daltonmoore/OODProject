using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    public static GameObject player;
    public static GameState instance;
	public static int SCORE = 0;
	public static int LIVES = 3;
	public static int TIME_ALIVE = 0;
    public bool gameStart = false;
    public bool gameOver = false;
    public static double respawnTimer;
    public static bool dead;


    private void Awake()
    {
        player = Resources.Load("Player") as GameObject;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start () {
        
	}

    public static void die()
    {
        dead = true;
        respawnTimer = 3;
        Destroy(GameObject.Find("Player"));
    }

	void Update () {
        if (dead)
        {
            respawnTimer -= Time.deltaTime;
            if(respawnTimer < 0)
            {
                dead = false;
                Instantiate(  player, transform.position, Quaternion.identity);
            }
        }

		TIME_ALIVE = TIME_ALIVE + 1; // Maybe this can be used somewhere?
	}

    void sharkDead()
    {
        gameOver = true;
    }
}
