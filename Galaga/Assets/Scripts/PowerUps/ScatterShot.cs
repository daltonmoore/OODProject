using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterShot : Powerup {
    public override void Change(Player player)
    {
        player.setPS(true);
        player.setScatter(true);
    }

    public override float getTimer()
    {
        return 5;
    }

    public override void Revert(Player player)
    {
        player.setPS(false);
        player.setScatter(false);
    }

}
