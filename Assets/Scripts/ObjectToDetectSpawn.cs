using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToDetectSpawn : MonoBehaviour {

	private float ObjectType = 2f;
	private float xScale;
	private float yScale;
	private float zScale;
	private GameObject Plane;

	void Awake()
	{
		//Randomly generates numbers for shape type and size and prints the size of the object
		//ObjectType = Random.Range(1, 5); 
		xScale = Random.Range(10f, 25f);
		yScale = Random.Range(1f, 3f);
		zScale = Random.Range(1f, 10f);
		Debug.Log("Scale = " + xScale + ", " + yScale + ", "+ zScale);

		if (ObjectType == 1f)
		{
			//New generation for cube shape
			Debug.Log("Cube");
			GameObject DetectionObject = GameObject.CreatePrimitive(PrimitiveType.Cube); //Creates the cube shape
			DetectionObject.transform.position = new Vector3(0, 0.5f, 0); //Ensures it is located on the plane/ground
 			DetectionObject.transform.localScale = new Vector3 (xScale, 2*yScale, zScale); //Sizes the object based on the randomly generated scale
			DetectionObject.name = DetectionObject.name.Replace("Cube", "Detection Object"); //Changes name to "Detection Object" so it can be detected by ASVs
			DetectionObject.AddComponent<ObjectController>(); //Adds ObjectController script so user can control movement of Detection Object
		}
		else if (ObjectType == 2f)
		{
			//New generation for sphere shape
			Debug.Log("Sphere");
			GameObject DetectionObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			DetectionObject.transform.position = new Vector3(0, 0.5f, 0);
 			DetectionObject.transform.localScale = new Vector3 (xScale, 2*yScale, xScale);
			DetectionObject.name = DetectionObject.name.Replace("Sphere", "Detection Object");
			DetectionObject.AddComponent<ObjectController>();
		}
		else if (ObjectType == 3f)
		{
			//New generation for cylinder shape
			Debug.Log("Cylinder");
			GameObject DetectionObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			DetectionObject.transform.position = new Vector3(0, 0.5f, 0);
 			DetectionObject.transform.localScale = new Vector3 (xScale, 2*yScale, zScale);
			DetectionObject.name = DetectionObject.name.Replace("Cylinder", "Detection Object");
			DetectionObject.AddComponent<ObjectController>();
		}
		else if(ObjectType == 4f)
		{
			//New generation for capsule shape
			Debug.Log("Capsule");
			GameObject DetectionObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			DetectionObject.transform.position = new Vector3(0, 0.5f, 0);
 			DetectionObject.transform.localScale = new Vector3 (xScale, 2*yScale, zScale);
			DetectionObject.name = DetectionObject.name.Replace("Capsule", "Detection Object");
			DetectionObject.AddComponent<ObjectController>();
		}
		Plane = GameObject.Find("Plane");
        var script = Plane.GetComponent<ASVSpawn>();
        script.ObjSize = xScale/2 + 20;
	}
}
