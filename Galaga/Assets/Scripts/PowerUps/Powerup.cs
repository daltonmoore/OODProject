using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour {
	public abstract int getTimer();
	public abstract IEnumerator powerup(Player player);
}
