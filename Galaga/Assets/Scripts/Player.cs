using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab, bulletSpawn;
    public GameState gameState;
    public float speed = 1f / 6f;
    public float bulletSpeed = 400;
    private bool canMove = true;
    public Vector3 startPosition;
    private bool PowerUpState = false;
    private bool scatter = false;


    // Use this for initialization
    void Start()
    {
        startPosition = gameObject.transform.position;
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();

    }

    void move()
    {
        if (canMove)
        {
            if (PowerUpState == false)
            {
                float x = Input.GetAxis("Horizontal");
                if (x * speed > 0)
                {
                    GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("PlayerLSWip");
                }
                else if (x * speed == 0)
                {
                    GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("PlayerWip");
                }
                else
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerRSWip");

                transform.Translate(x * speed, 0, 0);
            }
            else
            {
                float x = Input.GetAxis("Horizontal");
                if (x * speed > 0)
                {
                    GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("PlayerBLSWip");
                }
                else if (x * speed == 0)
                {
                    GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("PlayerBWip");
                }
                else
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerBRSWip");

                transform.Translate(x * speed, 0, 0);
            }
        }

      
    }

    void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (scatter == false)
            {
                GameObject bulletInstance = Instantiate(bulletPrefab);
                bulletInstance.transform.position = bulletSpawn.transform.position;
                Rigidbody2D r = bulletInstance.GetComponent<Rigidbody2D>();
                r.AddForce(Vector2.up * bulletSpeed);
                //r.AddForce(Vector2.left * 100);
                Destroy(bulletInstance, 2.5f);
            }
            else
            {
                GameObject bulletInstance = Instantiate(bulletPrefab);
                GameObject bulletInstance2 = Instantiate(bulletPrefab);
                GameObject bulletInstance3 = Instantiate(bulletPrefab);
                bulletInstance.transform.position = bulletSpawn.transform.position;
                bulletInstance2.transform.position = bulletSpawn.transform.position;
                bulletInstance3.transform.position = bulletSpawn.transform.position;
                Rigidbody2D r = bulletInstance.GetComponent<Rigidbody2D>();
                Rigidbody2D r2 = bulletInstance2.GetComponent<Rigidbody2D>();
                Rigidbody2D r3 = bulletInstance3.GetComponent<Rigidbody2D>();
                r.AddForce(Vector2.up * bulletSpeed);
                r2.AddForce(Vector2.up * bulletSpeed);
                r3.AddForce(Vector2.up * bulletSpeed);
                r2.AddForce(Vector2.left * 100);
                r3.AddForce(Vector2.right * 100);
                Destroy(bulletInstance, 2.5f);
                Destroy(bulletInstance2, 2.5f);
                Destroy(bulletInstance3, 2.5f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemyBullet" || other.tag == "enemy")
        {
            Destroy(other.gameObject);
            gameState.die(this.gameObject);
        }

        if (other.tag == "PowerUp")
        {
            Powerup p = other.gameObject.GetComponent<Powerup>();
            StartCoroutine(p.powerup(this));
            //other.gameObject.GetComponent<PwrUpController>().runPwrUp(this);
            Destroy(other.gameObject);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
      /*  if (collision.tag == "grabber")
        {
            canMove = false;
            transform.position = Vector2.MoveTowards(transform.position, collision.transform.position + 
                new Vector3(0, 10), 10 * Time.deltaTime);
        }*/
    }

    public void setPS(bool val)
    {
        PowerUpState = val;
    }

    public void setScatter(bool val)
    {
        scatter = val;
        Debug.Log("scatter changing");
    }

    public void addLife()
    {
        gameState.AddLife(this.gameObject);
    }

}
