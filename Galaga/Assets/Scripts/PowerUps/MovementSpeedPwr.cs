using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedPwr : Powerup
{
    float MoveSpeed;

    public override void Change(Player player)
    {
        player.setPS(true);
        MoveSpeed = player.speed;
        player.speed = 1.5f / 6f;
    }

    public override float getTimer()
    {
        return 15;
    }

    public override void Revert(Player player)
    {
        player.setPS(false);
        player.speed = MoveSpeed;
    }

}
