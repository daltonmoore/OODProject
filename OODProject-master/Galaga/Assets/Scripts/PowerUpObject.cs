using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour {
    BlankPowerUp p = new BlankPowerUp();
    // Made to hold the decorated powerup
    void Start () {
        //BlankPowerUp p = new BlankPowerUp();
        BSD d1 = new BSD();
        d1.setPower(p);
        d1.Decorate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float giveTimer()
    {
        return p.Timer;
    }
}
