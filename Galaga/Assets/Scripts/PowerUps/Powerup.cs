using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour {
    public abstract float getTimer();
    public abstract void Change(Player player);
    public abstract void Revert(Player player);

    public IEnumerator powerup(Player player)
    {
        Change(player);
        yield return new WaitForSeconds(getTimer());
        Revert(player);
    }
}
