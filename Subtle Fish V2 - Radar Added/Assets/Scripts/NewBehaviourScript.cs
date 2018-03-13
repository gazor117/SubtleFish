using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject player;
	public Chase chase;
	public float timer, angle, offSet; 
	private float originalTime, counter;

	void Start () {
		originalTime = timer; 

	}

	void Update () { 
		counter += Time.deltaTime;

		Vector3 lookAt = player.transform.position - transform.position;
		lookAt.Normalize ();
		float rotZ = Mathf.Atan2 (lookAt.y, lookAt.x) * Mathf.Rad2Deg;

		if (counter > originalTime) {
			originalTime += timer;
			angle *= -1;
		}

		if (chase.alert == false) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (transform.rotation.x, transform.rotation.y, angle), Time.deltaTime / timer);
		} else {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, 0, rotZ-offSet), Time.deltaTime / timer);
		} 


	}
}
