using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	private float speed = 5f;
	private bool isJumping = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		Vector3 curPos = this.gameObject.transform.position;
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
			Vector3 newPos = new Vector3(Input.GetAxis ("Horizontal") * speed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
			GetComponent<Rigidbody>().velocity = newPos; 
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping) {
			Vector3 newPos = new Vector3(GetComponent<Rigidbody>().velocity.x, speed, GetComponent<Rigidbody>().velocity.z);
			GetComponent<Rigidbody>().velocity = newPos;
		}
		if(this.GetComponent<Rigidbody>().position.y >= 1.4) isJumping = true;
		else isJumping = false;
	}
}
