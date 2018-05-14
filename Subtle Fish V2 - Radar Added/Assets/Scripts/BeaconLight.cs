using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconLight : MonoBehaviour {


	Light beaconLight;
	Color pink;
	Color purple;
	Color darkOrange; 
	Color maroon;
	public static Color firstColor, secondColor, thirdColor, fourthColor; // first - fourth colors in the current beacon sequence
	public static string[] colors = new string[4] {"yellow", "orange", "purple", "green"};
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
	public static int color1, color2, color3, color4;
	private int privateColor1, privateColor2, privateColor3, privateColor4;
	public static bool playerInBeacon = false;
	public static bool beaconComplete;
	private bool closestBeacon;
	bool playSound = false;
	bool toggleChange = false;
    //bool sequenceComplete = false;
    public AudioSource BeaconComplete;





	void Start () {
		beaconLight = GetComponentInChildren<Light> ();
		pink = new Color (255/255f, 192/255f, 203/225f);
		purple = new Color (255/255f, 0 / 255f, 255/255f);
		darkOrange = new Color (255 / 255f, 127 / 255f, 80 / 255f);
		maroon = new Color (255/255f, 0/255f, 0/225f);

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
		if (currentNum == 1) { // Randomly assigns four colors in the beacon sequence
			privateColor1 = randomIndex;
		}if (currentNum == 2) {
			privateColor2 = randomIndex;
		}if (currentNum == 3) {
			privateColor3 = randomIndex;
		}if (currentNum == 4) {
			privateColor4 = randomIndex;
			startSequenceTimer = true;
		}

		color1 = privateColor1;
		color2 = privateColor2;
		color3 = privateColor3;
		color4 = privateColor4;



		if (startSequenceTimer) {
			if (currentColor == 1) {
				if (colors [color1] == "yellow") {
					beaconLight.color = maroon;
					firstColor = maroon;
				}
				if (colors [color1] =="orange") {
					beaconLight.color = darkOrange;
					firstColor = darkOrange;
				}
				if (colors [color1] == "purple") {
					beaconLight.color = purple;
					firstColor = purple;
				}
				if (colors [color1] == "green") {
					beaconLight.color = Color.green;
					firstColor = Color.green;
				}
			}
			if (currentColor == 2) {
				if (colors [color2] == "yellow") {
					beaconLight.color = maroon;
					secondColor = maroon;
				}
				if (colors [color2] == "orange") {
					beaconLight.color = darkOrange;
					secondColor = darkOrange;
				}
				if (colors [color2] == "purple") {
					beaconLight.color = purple;
					secondColor = purple;
				}
				if (colors [color2] == "green") {
					beaconLight.color = Color.green;
					secondColor = Color.green;
				}
			}
			if (currentColor == 3) {
				if (colors [color3] == "yellow") {
					beaconLight.color = maroon;
					thirdColor = maroon;
				}
				if (colors [color3] == "orange") {
					beaconLight.color = darkOrange;
					thirdColor = darkOrange;
				}
				if (colors [color3] == "purple") {
					beaconLight.color = purple;
					thirdColor = purple;
				}
				if (colors [color3] == "green") {
					beaconLight.color = Color.green;
					thirdColor = Color.green;
				}
			}
			if (currentColor == 4) {
				if (colors [color4] == "yellow") {
					beaconLight.color = maroon;
					fourthColor = maroon;
				}
				if (colors [color4] == "orange") {
					beaconLight.color = darkOrange;
					fourthColor = darkOrange;
				}
				if (colors [color4] == "purple") {
					beaconLight.color = purple;
					fourthColor = purple;
				}
				if (colors [color4] == "green") {
					beaconLight.color = Color.green;
					fourthColor = Color.green;
				}
			}
		}
		if (playSound) {
			BeaconComplete.Play ();
			toggleChange = true;
			playSound = false;
		}

		Timer ();
		if (beaconComplete && closestBeacon) {
			BeaconCompleted ();
		}
		//print (currentColor);
		//print (waitTime);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") {
			print ("Player Detected");
			playerInBeacon = true;
			closestBeacon = true;

		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") {
			print ("Player outside beacon");
			playerInBeacon = false;
			closestBeacon = false;
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
			//print ("Beacon Enabled");
			currentColor = 1;
			waitTime = beaconWaitTime;
		}

	}

	void BeaconCompleted()
	{
		beaconLight.color = Color.white;
		currentColor = 5;
		beaconLight.enabled = true;
		if (toggleChange == false) {
			playSound = true;
		}
	}

}
