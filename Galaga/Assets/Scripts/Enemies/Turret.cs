using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, Enemy
{

    public GameObject bulletPrefab;
    public GameObject PUp;
    public float timer = 0;
    public float bulletSpeed = 300;
    public float coneSize = 250;
    public float speed = 30f;
    int c1 = 0;
    int c2 = 0;
    int rnd;

    public void Start()
    {
        rnd = Random.Range(0, 10);
    }

    public void Update()
    {
        Fire();
        Move();
    }

    public void Move()
    {
        c1++;
        if (c1 < 20 && c2 == 0)
        {
            transform.Translate(1 * (1f / 120f), 0, 0);
        }
        else
        {
            c2++;
            transform.Translate(-1 * (1f / 120f), 0, 0);
        }
        if (c2 > 40)
        {
            c1 = -20;
            c2 = 0;
        }
    }

    public void Fire()
    {
		if (timer + 1.5f + Random.value < Time.time && !GameState.dead)
        {
            timer = Time.time;
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.position = transform.position + new Vector3(0, -0.5f);
            Rigidbody2D r = bulletInstance.GetComponent<Rigidbody2D>();

            float width = Random.value * coneSize + (-Random.value * coneSize);
            r.AddForce(Vector2.right * width + Vector2.down * bulletSpeed);

            Destroy(bulletInstance, 4);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            if(rnd == 5)
            SpawnPUp();

            Destroy(gameObject);
            Destroy(other.gameObject);
            GameState.SCORE += 100;
        }
    }

    public void SpawnPUp()
    {
        rnd = Random.Range(0, 100);

        if (rnd >= 1 && rnd < 25)
        {
            Debug.Log("Bullet Speed " + rnd);
            PUp = Resources.Load<GameObject>("BlankPower");

        }
        else if (rnd >= 25 && rnd < 50)
        {
            Debug.Log("Movement Speed " + rnd);
            PUp = Resources.Load<GameObject>("MoveSpeed");
        }
        else if (rnd >= 50 && rnd < 75)
        {
            Debug.Log("1up " + rnd);
            PUp = Resources.Load<GameObject>("OneUP");
        }
        else if (rnd >= 75 && rnd < 100)
        {
            Debug.Log("Scatter Shot " + rnd);
            PUp = Resources.Load<GameObject>("ScatterShot");
        }

        Instantiate(PUp, transform.position, transform.rotation);
    }
}
