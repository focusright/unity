using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	public Animator anim;

	public AudioSource punchHit;

	public AudioSource swingSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) { 
			this.anim.Play( "Punch" );
		}
	
	}

	void PlayPunchHitSound() {

		punchHit.Play();

	}

	void PlaySwingSound() {

		swingSound.Play();

	}


}
