using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	// Declare a public variable to reference the Main Camera
	public const float PROXIMITY_DISTANCE = 2f;
	private GameObject currentTarget;
	//private Scene1_Script1 waypointManager;
	Rigidbody2D rb;
	public float DECELERATION_FACTOR = 2.0f;
	// Now variables needed by FixedUpdate
	Vector2 source;
	Vector2 target;
	Vector2 outputVelocity;
	// And arrive
	Vector2 directionToTarget;
	Vector2 velocityToTarget;
	float distanceToTarget;
	float speed;

	// Setup a variable to point to the Animator Controller for the character
	Animator animator;

	// Use this for initialization
	void Awake ()
	{
		// Get the WaypointManager from the camera and then the first object
		//waypointManager = mainCamera.GetComponent<Scene1_Script1> ();
		currentTarget = NextWaypoint (null);

		// Get the orientation of Teddy and look at current target
		//GetComponent<Transform>().LookAt(currentTarget.transform);

		//get the Animator Controller Component from the character component hierarchy
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		source = transform.position;
		target = currentTarget.transform.position;

		// Get the orientation of Teddy and look at current target
		//GetComponent<Transform>().LookAt(currentTarget.transform);

		outputVelocity = Arrive (source, target);
		rb.AddForce (outputVelocity/8);
		// Check the distance from object to target, and make query
		// When it moves within the PROXIMITY_DISTANCE


		if (Vector3.Distance (source, target) < PROXIMITY_DISTANCE) {
			currentTarget = NextWaypoint (currentTarget);
		}

		Debug.Log (Vector3.Distance (source, target));

		// Manage Animations
		// If diatance betweeen source and target < 6 then set Walk animation
		// Otherwise set Run Animation
		/*if (Vector3.Distance (source, target) < 6.0) {

			Debug.Log (Vector3.Distance (source, target));

			animator.SetBool ("runBool", false);
			animator.SetBool ("walkBool", true);

		} else if(Vector3.Distance (source, target) > 6.0) {

			animator.SetBool ("runBool", true);
			animator.SetBool ("walkBool", false);
		}*/
	}
	// Arrive function
	private Vector3 Arrive (Vector3 source, Vector3 target)
	{
		distanceToTarget = Vector3.Distance (source, target);
		directionToTarget = Vector3.Normalize (target - source);
		speed = distanceToTarget / DECELERATION_FACTOR;
		velocityToTarget = speed * directionToTarget;
		return velocityToTarget - GetComponent<Rigidbody2D> ().velocity;
	}

	int nextIndex;
	public GameObject[] waypoints;

	public GameObject NextWaypoint (GameObject current)
	{
		if (current != null) {
			// Find array index of given waypoint
			for (int i = 0; i < waypoints.Length; i++) {
				// Once found calculate next one
				if (current == waypoints [i]) {
					// Modulus operator helps to avoid to go out of bounds
					// And resets to 0 the index count once we reach the end of the array
					nextIndex = (i + 1) % waypoints.Length;
				}
			}
		} else {
			// Default is first index in array 
			nextIndex = 0;
		}
		return waypoints [nextIndex];
	}
}
