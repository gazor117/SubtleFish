using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFallAnim : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D () {
		anim.SetBool ("rockFall", true);

	}
}
