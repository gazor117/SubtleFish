using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

	public bool alert;
	public GameObject player;
	public float timer, speed;
	private float counter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;

		if (counter > 0) {
			alert = true;
		} else {
			alert = false;
		}

		if (alert == true) {
			transform.position = Vector3.Lerp (transform.position, player.transform.position, (speed/Vector3.Distance(transform.position, player.transform.position))*Time.deltaTime);
		} 
	}

	public void setOff () {

		counter = timer;
	}
}
