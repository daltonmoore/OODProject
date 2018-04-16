using System.Collections.Generic;
using UnityEngine;

class Speeder : MonoBehaviour, Enemy
{
    public float timer = 0;
    public float bulletSpeed = 300;
    public float coneSize = 250;
    public int fireCount = 0;
    public Vector2 startPosition;
    public Transform player;
    public float radius = 10f;
    public float speed = 13f;
    public bool offsetIsCenter = true;
    public Vector2 offset;
    GameState instance;
    int randomrange;

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Speeder");
        bulletSpeed = 400;
        coneSize = 400;
        startPosition = gameObject.transform.position;

        if(GameObject.Find("Player"))
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (offsetIsCenter)
        {
            offset = transform.position;
        }
    }

    void Awake()
    {
        instance = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public void Fire()
    {

    }

    public void Move()
    {


        if (GameObject.FindGameObjectWithTag("Player") == null)
            transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(0, -30), speed * Time.deltaTime);

        else
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = Vector2.MoveTowards(transform.position, player.position +
                                    new Vector3(0, -3), speed * Time.deltaTime);
        }
    }

    public void Update()
    {
        timer++; 
       Fire();
       Move();
        if(timer > 120f)
        {
            Destroy(gameObject);
        }
       
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
                Destroy(gameObject);
                Destroy(other.gameObject);
        }
            

        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    

    }
}
