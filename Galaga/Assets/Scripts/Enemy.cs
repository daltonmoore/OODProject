using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    protected float timer, bulletSpeed, coneSize;

    public abstract void fire();

    private void Update()
    {
        fire();
    }
}
