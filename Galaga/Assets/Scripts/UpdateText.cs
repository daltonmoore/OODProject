using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour {
	public Text scoreLabel;
	public Text livesLabel;

	void Start() {
		scoreLabel = GameObject.Find("ScoreText").GetComponent<Text>();
		livesLabel = GameObject.Find("LivesText").GetComponent<Text>();
	}

	void Update() {
		updateText();
	}

	void updateText() {
		if (scoreLabel == null || livesLabel == null) {
			return;
		}

		scoreLabel.text = "Score: " + GameState.SCORE;
		livesLabel.text = "Lives: " + GameState.LIVES;
	}
}
