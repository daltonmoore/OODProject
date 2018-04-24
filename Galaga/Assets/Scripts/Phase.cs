using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour {

    GameObject enemy;
    GameState instance;
    Spawner spawner;
    int maxEnemyCount = 5;
    int counter = 0;
    int phase = 1;
    int maxPhase = 3;
    float spawnrate = 3;
    float nextspawn = 3;
    bool pause = false;
    float pauseT;

    public int getPhase()
    {
        return phase;
    }

    // Use this for initialization
    void Start () {
        printPhase();
	}

    private void Awake()
    {
        instance = GameObject.Find("GameState").GetComponent<GameState>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();

    }

    // Update is called once per frame
    void Update()
    {
        //print(GameObject.FindGameObjectsWithTag("enemy"));

        if (GameState.TIME_ALIVE > 5 && (counter < maxEnemyCount) && !GameState.dead && !pause)
        {
            if (Time.time > nextspawn)
            {
                nextspawn = Time.time + spawnrate;
                enemy = spawner.Fire(phase);
                counter++;
                print(counter);
            }
            else if (Time.time > nextspawn - .5)
            {
                spawner.prepareFire();
            }
        }
        else if (counter == maxEnemyCount && GameObject.FindGameObjectsWithTag("enemy").GetLength(0) == 0)
        {
            

            spawner.pauseSpawner();
            if (pause == false)
            {
                spawner.defeatable = true;
                pauseT = Time.time + 3;
                pause = true;
            }
            if (Time.time > pauseT)
            {
                pause = false;
                spawner.defeatable = false;
                counter = 0;
                maxEnemyCount += 5;
                phase++;
                printPhase();
                spawnrate = spawnrate - 0.5f;
                if (spawnrate < 0.5)
                    spawnrate = 0.5f;
                spawner.unpauseSpawner();
            }
        }
    }

    void printPhase()
    {
        print("Phase " + phase);
    }

    public int getCounter()
    {
        return counter;
    }
}
