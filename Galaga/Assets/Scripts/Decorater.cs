using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Decorater : Powerup {
    protected Powerup power;

    public void setPower(Powerup power)
    {
        this.power = power;
    }

    public override void Decorate()
    {
        if (power != null)
        {
            power.Decorate();
        }
    }

    public Powerup GetPowerup()
    {
        return power;
    }

}
