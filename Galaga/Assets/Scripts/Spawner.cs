
using UnityEngine;

public class Spawner : MonoBehaviour
{

    int c1= 0;
    int c2 = 0;

    void Start()
    {

    }

    void Update()
    {
        Move(); 
    }

    private void Move()
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
