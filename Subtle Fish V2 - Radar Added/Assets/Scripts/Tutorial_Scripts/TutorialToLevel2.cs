using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialToLevel2 : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "Player") {
			anim.SetBool ("Fade", true);
			StartCoroutine (endScene ());
		}
	}

	IEnumerator endScene () {
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("Level 2", LoadSceneMode.Single);
	}
}