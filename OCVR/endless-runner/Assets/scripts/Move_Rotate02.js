
//function OnTriggerEnter (other : Collider) {
	//	Destroy(other.gameObject);
		
//}

var masterobject : GameObject;
var boxstraight : GameObject; 
private var thePosition = Vector3 (0,0,0);
function OnTriggerEnter (other2 : Collider) {


var whichdirection: int = Random.Range(1, 4);
//var whichdirection: int = 2;
print (whichdirection);
		
		//straight
		if (whichdirection == 1)
		{
		masterobject.transform.position = masterobject.transform.TransformPoint(0, 0, 16);
		print ("problems??????");
		// here problems
		boxstraight.transform.position = masterobject.transform.position;
		boxstraight.transform.rotation = masterobject.transform.rotation;		
		}	
		
		//left			
		if (whichdirection == 2)
		{	
		masterobject.transform.position = masterobject.transform.TransformPoint(0, 0, 12);	
		masterobject.transform.localEulerAngles.y = masterobject.transform.localEulerAngles.y - 90;
		boxstraight.transform.position = masterobject.transform.position;
		boxstraight.transform.rotation = masterobject.transform.rotation;
	
				
		}	
		
		//right
		if (whichdirection == 3)
		{
		masterobject.transform.position = masterobject.transform.TransformPoint(0, 0, 20);	
		masterobject.transform.localEulerAngles.y = masterobject.transform.localEulerAngles.y + 90;
		boxstraight.transform.position = masterobject.transform.position;
		boxstraight.transform.rotation = masterobject.transform.rotation;
			
		}				
	
	
}



