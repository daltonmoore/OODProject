using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Bullet Speed Decorater
 class BSD : Decorater {
    public override void Decorate()
    {
        base.Decorate();
        power.Timer = 10;
    }

    public float getID()
    {
        return 1;
    }

}
