using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankPowerUp : Powerup {
    float speed;

    public override void Change(Player player)
    {
        player.setPS(true);
        speed = player.bulletSpeed;
        player.bulletSpeed = 750;
    }

    public override float getTimer()
    {
        return 10;
    }

    public override void Revert(Player player)
    {
        player.setPS(false);
        player.bulletSpeed = speed;
    }

}
