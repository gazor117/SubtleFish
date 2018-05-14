using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeY;
	public Transform FollowCamera;
	public GameObject Player;
	public GameObject Spawnpoint;
	[Range(0f,5f)] 
	public float camHeight = 0;

	public float shakeTimer;
	public float shakeAmount;
	public bool insideCol = true;

	void Start () {
		Cursor.visible = false; 
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//Cursor.visible = false;
		//Player = GameObject.FindGameObjectWithTag ("Player4");
		if (col.tag == "mainCameraFollow") {
			insideCol = true; 
		}
		}

	void OnTriggerExit2D (Collider2D col)
	{
		//Cursor.visible = false;
		//Player = GameObject.FindGameObjectWithTag ("Player4");
		if (col.tag == "mainCameraFollow") {
			insideCol = false; 
		}
	}

	void FixedUpdate () {
		if (insideCol == true) {
			if (Player == null) {
				return;
			}
			float posY = Mathf.SmoothDamp (transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimeY);
			float posX = Mathf.SmoothDamp (transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeY);
			FollowCamera.position = new Vector3 (posX, posY + camHeight, -10);
		}
	}
	/*void Update () {

		if (shakeTimer >= 0) {
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x, transform.position.y + ShakePos.y, -10); 

			shakeTimer -= Time.deltaTime;
		}

	}


	public void ShakeCamera(float shakePwr, float shakeDur)
	{
		shakeAmount = shakePwr;
		shakeTimer = shakeDur;
	}

	public void RespawnCam() {
		//if 
	}*/
}



