using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BlankPowerUp : Powerup
{


    public override void Decorate()
    {

    }

    IEnumerator powerup( Player player )
        player.bulletSpeed = 600;
        yield return new WaitForSeconds(giveTimer());
        playerbulletSpeed = 400;
    }
}
