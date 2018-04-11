
using System;
using UnityEngine;

public class Spawner : MonoBehaviour, Enemy
{
    float spawnrate = 5;
    float nextspawn = 0;
    float nextspawn2 = 2;
    float spawnrate2 = 10;
    public GameObject enemy;
    public GameObject enemy2;
    int c1= 0;
    int c2 = 0;


    public void Start()
    {
        
    }

    public void Update()
    {
        Move();
        if (Time.time > nextspawn)
        {
            nextspawn = spawnrate + nextspawn;
            //Instantiate(enemy, transform.position, Quaternion.identity);
        }

        if(Time.time > nextspawn2)
        {
            nextspawn2 = spawnrate2 + nextspawn2;
            Instantiate(enemy2, transform.position + new Vector3(0,-2), Quaternion.identity);
        }
    }

    public void Move()
    {
        c1++;
        if (c1 < 200 && c2 == 0)
        {
            transform.Translate(1 * (1f / 30f), 0, 0);
        }
        else
        {
            c2++;
            transform.Translate(-1 * (1f / 30f), 0, 0);
        }
        if (c2 > 400)
        {
            c1 = -200;
            c2 = 0;
        }
    } 

    public void Fire()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
