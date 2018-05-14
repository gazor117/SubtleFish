using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	Rigidbody2D rb;
	public float speed, timer;
	float originalTime;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		originalTime = timer;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (originalTime > 0) {
			originalTime -= Time.deltaTime;
		}
		//if (originalTime > 0) {
		//	rb.velocity = (new Vector2 (speed, 0));
		//} else {
		rb.velocity = (new Vector2 (15+originalTime, 0));
		//}
	}
}
