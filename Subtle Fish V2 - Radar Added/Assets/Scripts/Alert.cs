using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour {

	public Chase chase;
	public Hide subCloak;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Player" && subCloak.canBeSeen == true) {
			chase.setOff ();
		}
	}
}
