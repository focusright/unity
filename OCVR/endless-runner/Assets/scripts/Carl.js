#pragma strict

private var anim : Animator ;	

function Start () {

}

function Awake()
	{
			anim = gameObject.GetComponent(Animator);
	}

	function Update() {
		// Move the object forward along its z axis 1 unit/second.
		//transform.Translate(Vector3.forward * Time.deltaTime * 4);
		// Move the object upward in world space 1 unit/second.
		//transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		
		
		
		if (Input.GetButtonDown ("left")) {
		//transform.localEulerAngles.y = transform.localEulerAngles.y - 90;
		anim.SetTrigger("turnleft");
		}
		
			if (Input.GetButtonDown ("right")) {
		//transform.localEulerAngles.y = transform.localEulerAngles.y + 90;
		anim.SetTrigger("turnright");
		}
		
	}
	
	
	
	
	
	
	