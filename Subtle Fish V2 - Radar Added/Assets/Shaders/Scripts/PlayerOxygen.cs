using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerOxygen : MonoBehaviour {

	float oxygen = 100, maxOxygen = 100;
	public float oxygenDecrease;
	public Slider oxygenUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oxygen -= oxygenDecrease;
		oxygenUI.value = oxygen / maxOxygen; 

		if (oxygen <= 0) {
			SceneManager.LoadScene ("Test", LoadSceneMode.Single);
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Air") {
			oxygen += maxOxygen - oxygen;
			Destroy (coll.gameObject);
			//coll.gameObject.GetComponent<AirBubbleDestroy> ().selfDestruct;
		}
	}
}
