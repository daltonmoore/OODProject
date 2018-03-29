using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
	public static int SCORE = 0;
	public static int LIVES = 3;
	public static int TIME_ALIVE = 0;

	void Start () {

	}

	void Update () {
		TIME_ALIVE = TIME_ALIVE + 1; // Maybe this can be used somewhere?
	}
}
