using UnityEngine;

interface Enemy 
{

    void Start();

    void Update();

    void Move();

    void Fire();

    void OnTriggerEnter2D(Collider2D other);

}

