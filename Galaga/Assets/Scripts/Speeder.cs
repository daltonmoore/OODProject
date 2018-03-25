using System.Collections.Generic;
using UnityEngine;

class Speeder : Enemy
{
    private void Start()
    {
        bulletSpeed = 400;
        coneSize = 400;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
