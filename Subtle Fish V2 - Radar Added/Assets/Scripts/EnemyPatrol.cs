using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	private int patrolState = 0;
	public GameObject patrolPoint1, patrolPoint2; 
	private Rigidbody2D rb;
	[Range(0,10)]
	public float speed;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		if (patrolState == 0) {
			rb.velocity = (new Vector2 (-speed, 0));
			if (transform.position.x < patrolPoint1.transform.position.x) {
				patrolState = 1;
			}
		}

		if (patrolState == 1) {
			rb.velocity = (new Vector2 (speed, 0));
			if (transform.position.x > patrolPoint2.transform.position.x) {
				patrolState = 0;
			}
		}
	}
}
