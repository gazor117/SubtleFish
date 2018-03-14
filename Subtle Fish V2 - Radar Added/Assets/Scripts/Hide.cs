using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	public Color color;
	Renderer rend;

	// Use this for initialization
	void Start () {
		rend = gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		rend.material.color = color; 

		if (Input.GetKeyDown (KeyCode.Mouse1))
			color.a -= 0.1f;
	}
}
