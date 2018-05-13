using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	public Color color;
	Renderer rend;
	public SubmarineMovement playerMove;
	private Renderer[] sprites;
	public static bool canBeSeen = true;

	// Use this for initialization
	void Start () {
		rend = gameObject.GetComponent<Renderer> ();
		sprites = gameObject.GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		 
		if (canBeSeen) {
			rend.enabled = true;
			//playerMove.enabled = true;
			foreach (SpriteRenderer child in sprites)
			{
				child.enabled = true;
			}

	}

		if (canBeSeen == false) {
			rend.enabled = false;
			//playerMove.enabled = false;
			foreach (SpriteRenderer child in sprites)
			{
				child.enabled = false;
			}

		}
	}
}
