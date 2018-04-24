using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUp : Powerup {

    public override void Change(Player player)
    {
        player.addLife();
    }

    public override float getTimer()
    {
        return 0;
    }

    public override void Revert(Player player)
    {
        //empty just adds a life
    }

}
