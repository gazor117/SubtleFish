﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmarineMovement : MonoBehaviour {

	Rigidbody2D rb;
	[Range(0,10)]
	public float speed;
	public float ySpeed;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");

		ySpeed = rb.velocity.y;

		if (rb.velocity.x < 3) {
			if (moveHor > 0) {
				rb.AddForce (new Vector2 (speed, 0));
				anim.SetBool ("facingRight", true);
			}
		}

		if (rb.velocity.x > -3) {
			if (moveHor < 0) {
				rb.AddForce (new Vector2 (-speed, 0));
				anim.SetBool ("facingRight", false);
			}
		}

		if (rb.velocity.y < 3) {
			if (moveVert > 0) {
				rb.AddForce (new Vector2 (0, speed));
			}
		}

		if (rb.velocity.y > -3) {
			if (moveVert < 0) {
				rb.AddForce (new Vector2 (0, -speed));
			}
		}

		anim.SetFloat ("xSpeed", rb.velocity.x);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
			SceneManager.LoadScene ("Test", LoadSceneMode.Single);

	}
}
