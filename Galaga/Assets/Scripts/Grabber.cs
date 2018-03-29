using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : Enemy {

    public float stoppingDistance;
    public float retreatDistance;
    public int fireCount = 0;
    public int health = 2;
    public Vector2 startPosition;
    public Transform player;
    public float waittime = 1f;
    public float radius = 10f;
    public float speed = 10f;
    public bool offsetIsCenter = true;
    public Vector2 offset;

    private void Start()
    {
        bulletSpeed = 400;
        coneSize = 400;
        startPosition = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (offsetIsCenter)
        {
            offset = transform.position;
        }
    }

    public override void fire()
    {

        if (timer + .75f + Random.value < Time.time)
        {
            timer = Time.time;
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.position = transform.position;
            Rigidbody2D r = bulletInstance.GetComponent<Rigidbody2D>();

            float width = Random.value * coneSize + (-Random.value * coneSize);
            r.AddForce(Vector2.right * width + Vector2.down * bulletSpeed);

            Destroy(bulletInstance, 2.5f);
        }
    }

    private void Update()
    {
        //waittime -= Time.time;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position + new Vector3(0,1), speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            if (health == 0)
                Destroy(gameObject);
            else
                health = health - 1;

            Destroy(other.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }
}


