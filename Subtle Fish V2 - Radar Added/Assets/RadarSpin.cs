using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarSpin : MonoBehaviour {

	public float turnSpeed;
	private float spin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spin += turnSpeed;

		transform.rotation = Quaternion.Euler(0, 0, spin);
	}
}
