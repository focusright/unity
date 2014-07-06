//http://docs.unity3d.com/ScriptReference/GameObject.CreatePrimitive.html
using UnityEngine;
using System.Collections;

public class Primitives : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

		plane.transform.parent = gameObject.transform;
		cube.transform.parent = gameObject.transform;
		sphere.transform.parent = gameObject.transform;
		capsule.transform.parent = gameObject.transform;
		cylinder.transform.parent = gameObject.transform;

		plane.transform.localPosition = Vector3.zero;
		cube.transform.localPosition = new Vector3(0, 0.5F, 0);
		sphere.transform.localPosition = new Vector3(0, 1.5F, 0);
		capsule.transform.localPosition = new Vector3(2, 1, 0);
		cylinder.transform.localPosition = new Vector3(-2, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
