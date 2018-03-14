using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightChanger : MonoBehaviour {

	Light playerLight;
	float lightTimerAmount = 3f;
	float lightCounter;
	Color startColor;
	bool startTimer = false;
	string playerColor;
	Color pink;
	Color purple;
	Color darkOrange;

	// Use this for initialization
	void Start () {
		playerLight = GetComponent<Light>();
		//startColor = playerLight.color;
		lightCounter = lightTimerAmount;
		pink = new Color (255/255f, 192/255f, 203/225f);
		purple = new Color (255/255f, 0 / 255f, 255/255f);
		darkOrange = new Color (255 / 255f, 127 / 255f, 80 / 255f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lightCounter < 1) {
			playerLight.color = Color.white;
		}
		if (Input.GetButton ("yellowLight")) {
			playerLight.color = Color.yellow;
			startTimer = true;
			lightCounter = lightTimerAmount;
		}
		if (Input.GetButton ("orangeLight")) {
			playerLight.color = darkOrange;
			startTimer = true;
			lightCounter = lightTimerAmount;
		}
		if (Input.GetButton ("purpleLight")) {
			playerLight.color = purple;
			startTimer = true;
			lightCounter = lightTimerAmount;
		}
		if (Input.GetButton ("greenLight")) {
			playerLight.color = Color.green;
			startTimer = true;
			lightCounter = lightTimerAmount;
		}

		//print (lightCounter);
		Timer ();
	}

	void Timer()
	{
		if (startTimer) {
			
			lightCounter -= Time.deltaTime;
			if (lightCounter < 0) {
				lightCounter = lightTimerAmount;
				startTimer = false;
			}
		}

	}
}
