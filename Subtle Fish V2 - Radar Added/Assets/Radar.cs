using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

	public GameObject[] objectsTracked;
	List<GameObject> radarObjects;
	public GameObject radarPrefab;
	List<GameObject> borderObjects;
	[Range(0,20)]
	public float switchDistance;
	public Transform helpTransform;

	// Use this for initialization
	void Start () {
		createdRadarObjects ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < radarObjects.Count; i++) {
			if (Vector3.Distance (radarObjects [i].transform.position, transform.position) > switchDistance) {
				helpTransform.LookAt (radarObjects [i].transform);
				borderObjects [i].transform.position = transform.position + switchDistance * helpTransform.forward;
				borderObjects [i].layer = LayerMask.NameToLayer ("Radar");
				radarObjects [i].layer = LayerMask.NameToLayer ("Invisible");
			} else {
				borderObjects [i].layer = LayerMask.NameToLayer ("Invisible");
				radarObjects [i].layer = LayerMask.NameToLayer ("Radar");
			}
		}
	}

	void createdRadarObjects () {
		radarObjects = new List<GameObject> ();
		borderObjects = new List<GameObject> ();
		foreach (GameObject o in objectsTracked) {
			GameObject clone = Instantiate (radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
			radarObjects.Add (clone);
			GameObject borderClone = Instantiate (radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
			borderObjects.Add (borderClone);
		}
	}
}
