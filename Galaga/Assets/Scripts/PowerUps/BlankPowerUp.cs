using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankPowerUp : Powerup {

	public override int getTimer() {
		return 10;
	}

	public override IEnumerator powerup(Player player) {
        lock(player){
            float ret = player.bulletSpeed;
            player.bulletSpeed = 750;
            player.setPS(true);
            yield return new WaitForSeconds(getTimer());
            player.bulletSpeed = ret;
            player.setPS(false);
        }
	}
}
