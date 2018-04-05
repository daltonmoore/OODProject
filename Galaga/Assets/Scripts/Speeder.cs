using System.Collections.Generic;
using UnityEngine;

class Speeder : MonoBehaviour, Enemy
{
    public GameObject bulletPrefab;
    public float timer = 0;
    public float bulletSpeed = 300;
    public float coneSize = 250;
    public int fireCount = 0;
    public int health = 2;
    public Vector2 startPosition;
    public Transform player;
    public float radius = 10f;
    public float speed = 13f;
    public bool offsetIsCenter = true;
    public Vector2 offset;

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Speeder");
        bulletSpeed = 400;
        coneSize = 400;
        startPosition = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (offsetIsCenter)
        {
            offset = transform.position;
        }
    }

    public void Fire()
    {

    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position + new Vector3(0, -3), speed * Time.deltaTime);
    }

    public void Update()
    {
       
       Fire();
       Move();

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            if (health == 0)
                Destroy(gameObject);
            else
                health = health - 1;

            Destroy(other.gameObject);
        }

        if(other.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    

    }
}
