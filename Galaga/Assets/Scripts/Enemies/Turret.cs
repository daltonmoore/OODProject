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

    public void Start()
    {

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
        if (timer + 1.5f + Random.value < Time.time)
        {
            timer = Time.time;
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.position = transform.position;
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
            SpawnPUp();
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameState.SCORE += 100;
        }
    }

    public void SpawnPUp()
    {
        Instantiate(PUp, transform.position, transform.rotation);
    }
}
