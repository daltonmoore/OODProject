using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab, bulletSpawn;
    float speed = 1f / 8f;
    float bulletSpeed = 400;

	// Use this for initialization
	void Start ()
    {
        
	}

	// Update is called once per frame
	void Update ()
    {
        move();
        fire();
    }

    void move()
    {
        float x = Input.GetAxis("Horizontal");

        transform.Translate(x * speed, 0, 0);
    }

    void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.position = bulletSpawn.transform.position;
            Rigidbody2D r = bulletInstance.GetComponent<Rigidbody2D>();
            r.AddForce(Vector2.up * bulletSpeed);
            Destroy(bulletInstance, 2.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemyBullet")
        {
            Destroy(gameObject);
        }
    }
}
