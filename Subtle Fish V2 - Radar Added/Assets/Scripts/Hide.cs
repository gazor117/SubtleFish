using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	public Color color;
	Renderer rend;
	public SubmarineMovement playerMove;
	private Renderer[] sprites;
	public bool canBeSeen = true;

	// Use this for initialization
	void Start () {
		rend = gameObject.GetComponent<Renderer> ();
		sprites = gameObject.GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		 
		if (Input.GetMouseButtonDown (0)) {
			rend.enabled = true;
			playerMove.enabled = true;
			foreach (SpriteRenderer child in sprites)
			{
				child.enabled = true;
			}
			canBeSeen = true;
	}

		if (Input.GetMouseButtonDown (1)) {
			rend.enabled = false;
			playerMove.enabled = false;
			foreach (SpriteRenderer child in sprites)
			{
				child.enabled = false;
			}
			canBeSeen = false;
		}
	}
}
