using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour, Enemy
{

    public GameObject bulletPrefab;
    public float timer = 0;
    public float bulletSpeed = 300;
    public float coneSize = 250;
    public float speed = 30f;

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
        
    }

    public void Fire()
    {
        if (timer + .75f + Random.value < Time.time)
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
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameState.SCORE += 100;
        }
    }
}
