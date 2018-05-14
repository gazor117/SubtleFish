using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfCinematic : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void OnTriggerEnter2D () {
		anim.SetBool ("Fade", true);
		StartCoroutine (endScene ());
	}

	IEnumerator endScene () {
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
}
