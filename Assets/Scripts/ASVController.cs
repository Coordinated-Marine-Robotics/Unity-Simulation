using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASVController : MonoBehaviour
{
    public GameObject ObjectForDetection; //Defines Detection Object which is assigned in ASVSpawn
    private Transform ObjectTransform;
    private float MoveSpeed = 10; //Defines movement speed
    private float MaxDist = 1000; //Defines the max distance away from the ASV the object can be detected
    public float MinDist; //Defines the position away from the object at which the ASV should stop
    private float rotation = 120; //Defines idle rotation speed
    public float TargetAngle;
    public string ASVName;
    private float TargetPosX;
    private float TargetPosZ;
    private Vector3 TargetPos;
    //Rigidbody m_Rigidbody;

    void Awake()
    {
        ObjectForDetection = GameObject.Find("/Detection Object"); //Assigns the spawned detection object to a game object variable
        ObjectTransform = ObjectForDetection.transform; //Assigns the location of the detection object to a transfrom variable

        //Debug.Log(ASVSpawn.numberofASVs);
        //m_Rigidbody = GetComponent<Rigidbody>();
        //m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward); //Defines new vector 3 for location of ASV

            //if (Physics.Raycast(transform.position + transform.up, fwd, MaxDist)) // Casts a ray forwards of the maximum distance that triggers the if statement if it collides
            //{
                //if (Vector3.Distance(transform.position, ObjectTransform.position) <= MaxDist) //If the distance between ASV and detection object is less than max it triggers
                //{
                    transform.LookAt(ObjectTransform); //ASV looks at detection object
                    if (TargetAngle >= 0 && TargetAngle <= 90)
                    {

                        TargetPosX = ObjectTransform.position.x + MinDist*Mathf.Sin((Mathf.PI*TargetAngle)/180);
                        TargetPosZ = ObjectTransform.position.z + MinDist*Mathf.Cos((Mathf.PI*TargetAngle)/180);
                        TargetPos = new Vector3(TargetPosX, 0.5f, TargetPosZ);
                        transform.position = Vector3.MoveTowards(transform.position, TargetPos, MoveSpeed * Time.deltaTime);
                    }
                    if (TargetAngle > 90 && TargetAngle <= 180)
                    {

                        TargetPosX = ObjectTransform.position.x + MinDist*Mathf.Cos((Mathf.PI*TargetAngle)/180 - Mathf.PI/2);
                        TargetPosZ = ObjectTransform.position.z - MinDist*Mathf.Sin((Mathf.PI*TargetAngle)/180 - Mathf.PI/2);
                        TargetPos = new Vector3(TargetPosX, 0.5f, TargetPosZ);
                        transform.position = Vector3.MoveTowards(transform.position, TargetPos, MoveSpeed * Time.deltaTime);
                    }
                    if (TargetAngle > 180 && TargetAngle <= 270)
                    {
                        TargetPosX = ObjectTransform.position.x - MinDist*Mathf.Sin((Mathf.PI*TargetAngle)/180 - Mathf.PI);
                        TargetPosZ = ObjectTransform.position.z - MinDist*Mathf.Cos((Mathf.PI*TargetAngle)/180 - Mathf.PI);
                        TargetPos = new Vector3(TargetPosX, 0.5f, TargetPosZ);
                        transform.position = Vector3.MoveTowards(transform.position, TargetPos, MoveSpeed * Time.deltaTime);
                    }
                    if (TargetAngle > 270 && TargetAngle <= 360)
                    {
                        TargetPosX = ObjectTransform.position.x - MinDist*Mathf.Cos((Mathf.PI*TargetAngle)/180 - (3*Mathf.PI)/2);
                        TargetPosZ = ObjectTransform.position.z + MinDist*Mathf.Sin((Mathf.PI*TargetAngle)/180 - (3*Mathf.PI)/2);
                        TargetPos = new Vector3(TargetPosX, 0.5f, TargetPosZ);
                        transform.position = Vector3.MoveTowards(transform.position, TargetPos, MoveSpeed * Time.deltaTime);
                    }

                    //(180*TargetAngle)/Mathf.PI
                    //(180*TargetAngle)/Mathf.PI - Mathf.PI/2
                    //(180*TargetAngle)/Mathf.PI - Mathf.PI
                    //(180*TargetAngle)/Mathf.PI - (3*Mathf.PI)/2

                    /*if (Vector3.Distance(transform.position, ObjectTransform.position) >= MinDist) //If the distance between ASV and detection object is greater than min it triggers
                    {
                        transform.position += transform.forward * MoveSpeed * Time.deltaTime; //Move forward by the movement speed defined above
                    }
                    if (Vector3.Distance(transform.position, ObjectTransform.position) <= MinDist) //If the distance between ASV and detection object is less than min it triggers
                    {
                        transform.position += -transform.forward * MoveSpeed * Time.deltaTime; //Move backward by the movement speed defined above
                    }*/
                //}
                //print("There is something in front of the object!");
            //}
            //else //Rotate if the object isn't detected and therefore ASV is in idle mode
            //{
                //rotation += 36.0f * Time.deltaTime; //Define rotation speed
                //transform.rotation = Quaternion.Euler(0, rotation, 0); //Rotate by rotation speed defined above
                //print("No Object Detected");
            //}

    }
}
