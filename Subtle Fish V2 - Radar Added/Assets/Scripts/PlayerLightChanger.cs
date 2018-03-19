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
	public static string correctSequence;
	/*public static bool light1correct = false;
	public static bool light2correct = false;
	public static bool light3correct = false;
	public static bool light4correct = false;*/
	public int colorStage = 0;
	bool buttonPressed = false;


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
		buttonPressed = false;
		if (lightCounter < 1) {
			playerLight.color = Color.white;
		}
		if (Input.GetButtonDown ("yellowLight")) {
			playerLight.color = Color.yellow;
			startTimer = true;
			lightCounter = lightTimerAmount;
			buttonPressed = true;
		}
		if (Input.GetButtonDown ("orangeLight")) {
			playerLight.color = darkOrange;
			startTimer = true;
			lightCounter = lightTimerAmount;
			buttonPressed = true;
		}
		if (Input.GetButtonDown ("purpleLight")) {
			playerLight.color = purple;
			startTimer = true;
			lightCounter = lightTimerAmount;
			buttonPressed = true;}
		if (Input.GetButtonDown ("greenLight")) {
			playerLight.color = Color.green;
			startTimer = true;
			lightCounter = lightTimerAmount;
			buttonPressed = true;
		}

		if (colorStage == 4) {
			BeaconLight.beaconComplete = true;
		}

		if (colorStage == 3) {
			if (playerLight.color == BeaconLight.fourthColor && buttonPressed == true) {
				//print ("Color 4 correct");
				colorStage = 4;
				buttonPressed = false;
			} else if (playerLight.color != BeaconLight.fourthColor && buttonPressed == true){
				ResetPlayerColors ();
			}
		}

		if (colorStage == 2) {
			if (playerLight.color == BeaconLight.thirdColor && buttonPressed == true) {
				//print ("Color 3 correct");
				colorStage = 3;
				buttonPressed = false;
			} else if (playerLight.color != BeaconLight.thirdColor && buttonPressed == true){
				ResetPlayerColors ();
			}
		}
		if (colorStage == 1){
			if (playerLight.color == BeaconLight.secondColor && buttonPressed == true) {
				//print ("Color 2 correct");
				colorStage = 2;
				buttonPressed = false;
			} else if (playerLight.color != BeaconLight.secondColor && buttonPressed == true){
				ResetPlayerColors ();
			}
		}

		if (colorStage == 0) {
			if (playerLight.color == BeaconLight.firstColor && buttonPressed == true) {
				//print ("Color 1 correct");
				colorStage = 1;
				buttonPressed = false;
			} else if (playerLight.color != BeaconLight.firstColor && buttonPressed == true) {
				ResetPlayerColors ();
			}
		}
		//print (lightCounter);
		Timer ();
		print (colorStage);
		print (buttonPressed);
	}

	void Timer()
	{
		if (startTimer) {
			
			lightCounter -= Time.deltaTime;
			if (lightCounter < 0) {
				lightCounter = lightTimerAmount;
				//buttonPressed = false;
				startTimer = false;
			}
		}

	}

	void ResetPlayerColors()
	{
		colorStage = 0;
		buttonPressed = false;
	}
		
}
