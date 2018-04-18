using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour, Enemy
{

    public float attackTimer = 10;
    public float nextAttack;
    public int health = 2;
    public Transform player;
    public float speed = 10;
    public float frequency = 20f;
    public float magnitude = .5f;
    public Vector3 startPosition, pos, localscale, movePosition;
    public bool offsetIsCenter = true;
    public Vector2 offset;
    bool facingRight = true;
    bool miss = false;
    static int random;
    private Rigidbody2D body;
    DistanceJoint2D distanceJoint2D;

    public void Start()
    {

        random = Random.Range(-3, 0);
        startPosition = gameObject.transform.position;
        pos = gameObject.transform.position;
        localscale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (offsetIsCenter)
        {
            offset = transform.position;
        }
    }

    public void Fire()
    {
        attackTimer = 10;
    }

    public void Move()
    {

    }

    public void Update()
    {


        attackTimer -= Time.deltaTime;
        CheckMiss();
        if (attackTimer > 0)
        {

            CheckWhereToFace();
            if (facingRight)
            {
                moveRight();
            }
            else
                moveLeft();
        }
        else if (attackTimer < 0 && !miss)
        {

            transform.position = Vector3.MoveTowards(transform.position, player.position + new Vector3(0, random), speed * Time.deltaTime);

        }
        else if (miss)
        {
            movetoStart();
        }

        if (transform.position.y > 200)
        {
            Destroy(this.gameObject);
        }

    }

    void CheckMiss()
    {
        if (transform.position.y < player.position.y)
        {

            print("Miss = true");
            miss = true;
        }
    }

    void CheckWhereToFace()
    {
        if (pos.x < -7f)
            facingRight = true;
        else if (pos.x > 7f)
            facingRight = false;
        if ((((facingRight) && (localscale.x < 0) || ((!facingRight) && localscale.x > 0))))
            localscale.x *= -1;
        transform.localScale = localscale;
    }

    void moveRight()
    {
        pos += transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void moveLeft()
    {
        pos -= transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
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


    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Success stay");
            transform.position = Vector3.MoveTowards(transform.position, startPosition + new Vector3(0, 10), 30 * Time.deltaTime);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("left collider");




        }
    }


    void movetoStart()
    {

        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

        if (transform.position.Equals(startPosition))
        {
            miss = false;
            Fire();
            pos = startPosition;
        }
    }




}



