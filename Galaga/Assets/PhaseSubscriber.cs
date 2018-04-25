using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseSubscriber : Subscriber {
	private Text phaseText;

	/*
	 * Subscribe us to the phase. When it changes, we will know. 
	*/
	void Start () {
		Phase.subscribe(this);

		phaseText = this.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public override void notify() {
		if (phaseText == null) {
			return;
		}

		phaseText.text = "Phase " + Phase.getPhase();
		StartCoroutine(FadeTextToFullAlpha(2, phaseText));
	}
		
	public IEnumerator FadeTextToFullAlpha(float t, Text i) {
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f) {
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}
}
