using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the camera to follow the player at a specific offset controlled by the Vector 3 variable defined below

public class CameraController : MonoBehaviour {
    
    private Vector3 offset;
	
    public GameObject randomObject;

	void Start ()
    {
        offset = transform.position - randomObject.transform.position;
	}
	
	void LateUpdate () 
    {
        transform.position = randomObject.transform.position + offset;
	}
}
