using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconLight : MonoBehaviour {


	Light beaconLight;
	Color pink;
	Color purple;
	Color darkOrange; 
	string[] colors = new string[4] {"yellow", "orange", "purple", "green"};
	int randomIndex;
	string randomColor;
	int[] colorSequence;
	public float lightTimerAmount = 3f;
	public float beaconWaitTime = 3f;
	float waitTime;
	float lightCounter;
	bool startTimer = false;
	bool startSequenceTimer = false;
	int sequenceLength = 4;
	int currentNum = 0;
	int currentColor = 1;
	int color1, color2, color3, color4;
	//bool sequenceComplete = false;






	void Start () {
		beaconLight = GetComponentInChildren<Light> ();
		pink = new Color (255/255f, 192/255f, 203/225f);
		purple = new Color (255/255f, 0 / 255f, 255/255f);
		darkOrange = new Color (255 / 255f, 127 / 255f, 80 / 255f);

		lightCounter = lightTimerAmount; 
		waitTime = beaconWaitTime;

	}


	void Update () {
		//Random ran = new Random ();
		randomIndex = (Random.Range(0,4));
		/*if (lightCounter < 0.1f) {
			randomColor = colors [randomIndex];

		}

		if (randomColor == "blue") {
			beaconLight.color = Color.blue;
		}
		if (randomColor == "pink") {
			beaconLight.color = pink;
		}
		if (randomColor == "purple") {
			beaconLight.color = purple;
		}
		if (randomColor == "green") {
			beaconLight.color = Color.green;
		}*/

		currentNum ++;
		if (currentNum == 1) {
			color1 = randomIndex;
		}if (currentNum == 2) {
			color2 = randomIndex;
		}if (currentNum == 3) {
			color3 = randomIndex;
		}if (currentNum == 4) {
			color4 = randomIndex;
			startSequenceTimer = true;
		}

		if (startSequenceTimer) {
			if (currentColor == 1) {
				if (colors [color1] == "yellow") {
					beaconLight.color = Color.yellow;
				}
				if (colors [color1] =="orange") {
					beaconLight.color = darkOrange;
				}
				if (colors [color1] == "purple") {
					beaconLight.color = purple;
				}
				if (colors [color1] == "green") {
					beaconLight.color = Color.green;
				}
			}
			if (currentColor == 2) {
				if (colors [color2] == "yellow") {
					beaconLight.color = Color.yellow;
				}
				if (colors [color2] == "orange") {
					beaconLight.color = darkOrange;
				}
				if (colors [color2] == "purple") {
					beaconLight.color = purple;
				}
				if (colors [color2] == "green") {
					beaconLight.color = Color.green;
				}
			}
			if (currentColor == 3) {
				if (colors [color3] == "yellow") {
					beaconLight.color = Color.yellow;
				}
				if (colors [color3] == "orange") {
					beaconLight.color = darkOrange;
				}
				if (colors [color3] == "purple") {
					beaconLight.color = purple;
				}
				if (colors [color3] == "green") {
					beaconLight.color = Color.green;
				}
			}
			if (currentColor == 4) {
				if (colors [color4] == "yellow") {
					beaconLight.color = Color.yellow;
				}
				if (colors [color4] == "orange") {
					beaconLight.color = darkOrange;
				}
				if (colors [color4] == "purple") {
					beaconLight.color = purple;
				}
				if (colors [color4] == "green") {
					beaconLight.color = Color.green;
				}
			}
		}


		Timer ();
		//print (currentColor);
		print (waitTime);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") {
			print ("Player Detected");
		}
	}

	void Timer()
	{
		if (startTimer) {

			lightCounter -= Time.deltaTime;
			if (lightCounter < 0) {
				currentNum ++;
				lightCounter = lightTimerAmount;
				if (currentNum > sequenceLength -1) {
					startTimer = false;
				}
			}
		}

		if (startSequenceTimer) {

			lightCounter -= Time.deltaTime;
			if (lightCounter < 0) {
				beaconLight.color = Color.red;
				currentColor ++;
				lightCounter = lightTimerAmount;
				if (currentColor > sequenceLength) {
					BeaconWait ();
					//currentColor = 1;
				}
			}
		}
	}

	void BeaconWait()
	{
		waitTime -= Time.deltaTime;
		beaconLight.enabled = false;
		if (waitTime < 0) {
			beaconLight.enabled = true;
			print ("Beacon Enabled");
			currentColor = 1;
			waitTime = beaconWaitTime;
		}

	}
}
