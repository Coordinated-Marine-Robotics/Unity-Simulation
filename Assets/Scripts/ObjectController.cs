using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Takes the input of the keyboard arrow keys and moves the detection object in accordance with this value multiplied by movement speed

public class ObjectController : MonoBehaviour
{
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed); 
    }
}
