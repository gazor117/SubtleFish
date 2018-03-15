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
	public static bool light1correct = false;
	public static bool light2correct = false;
	public static bool light3correct = false;
	public static bool light4correct = false;


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

		if (playerLight.color == BeaconLight.firstColor) {
			print ("Color 1 correct");
			light1correct = true;
		}
		if (light1correct) {
			if (playerLight.color == BeaconLight.secondColor) {
				print ("Color 2 correct");
				light2correct = true;
			} else {
				ResetPlayerColors ();
			}
		}
		if (light2correct) {
			if (playerLight.color == BeaconLight.thirdColor) {
				print ("Color 3 correct");
				light3correct = true;
			} else {
				ResetPlayerColors ();
			}
		}
		if (light3correct) {
			if (playerLight.color == BeaconLight.fourthColor) {
				print ("Color 4 correct");
				light4correct = true;
			} else {
				ResetPlayerColors ();
			}
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

	void ResetPlayerColors()
	{
		light1correct = false;
		light2correct = false;
		light3correct = false;
		light4correct = false;
	}
}
