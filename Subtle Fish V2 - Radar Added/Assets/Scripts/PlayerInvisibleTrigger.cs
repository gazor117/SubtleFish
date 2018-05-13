using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvisibleTrigger : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player") {
			

			Hide.canBeSeen = false;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") {
			
			Hide.canBeSeen = true;
		}
	}
}
