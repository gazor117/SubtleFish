using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePatrolPoint : MonoBehaviour {

	public GameObject newPatrolPointPos;
	public GameObject PatrolPoint;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") {
			PatrolPoint.transform.position = newPatrolPointPos.transform.position;
		}
	}
}
