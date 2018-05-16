
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASVSpawn : MonoBehaviour 
{
	
    public GameObject prefabASV; //Defines ASV to be spawned
    public static float numberofASVs;
    //max position bounds for location of ASVs due to plane
    private float minxpos = -50f;
    private float maxxpos = 50f; 
    private float minzpos = -50f;
    private float maxzpos = 50f;
    private double AngleFromObject;
    private string temp;
    private GameObject ASVn;
    private int ASVNum;
    private int Counter = 0;
    public float ObjSize;
    public static float TargetAngle;
    //public Script script;
    List<double> Angles = new List<double>();
    List<int> Names = new List<int>();

	// Use this for initialization
	public void Awake()
    {
		numberofASVs = Random.Range(50, 50); //Defines the number of ASVs to be spawned between the range of 3 and 10
        //Debug.Log(numberofASVs); //Print this value

        for (int i = 0; i < numberofASVs; i++) //Do the code below for every ASV which has been spawned
        {	
            //float angle = i * Mathf.PI*2f / numberofASVs;
            //Debug.Log((180*angle)/Mathf.PI);

            Vector3 position = new Vector3(Random.Range(minxpos, maxxpos), Random.Range(0.5f, 0.5f), Random.Range(minzpos, maxzpos)); //Randomly generate the position with the bounds defined above
			Debug.Log(position); //Print this value
            GameObject ASV = Instantiate(prefabASV, position, Quaternion.identity) as GameObject; //Generate the ASV prefab as a new game object at the location generated above
            int j = i + 1;
            string ASVnumber = j.ToString();
            ASV.name = ASV.name.Replace("(Clone)", " " + ASVnumber); // Convert ASV name to specific number for ASV

            Names.Add(j);

            if (position.x > 0)
            {
                if  (position.z > 0)
                {
                    AngleFromObject = 180*(Mathf.PI / 2 - Mathf.Atan(Mathf.Abs(position.z) / Mathf.Abs(position.x)))/Mathf.PI;
                }
                else
                {
                    AngleFromObject = 180*(Mathf.PI - Mathf.Atan(Mathf.Abs(position.x) / Mathf.Abs(position.z)))/Mathf.PI;
                }
            }
            if (position.x < 0)
            {
                if(position.z < 0)
                {
                    AngleFromObject = 180*((3 * Mathf.PI) / 2 - Mathf.Atan(Mathf.Abs(position.z) / Mathf.Abs(position.x)))/Mathf.PI;
                }
                else
                {
                    AngleFromObject = 180*(2 * Mathf.PI - Mathf.Atan(Mathf.Abs(position.x) / Mathf.Abs(position.z)))/Mathf.PI;
                }
            } 
            Angles.Add(AngleFromObject);
        }
        IList ASV_Order = PythonInterpreter.PatchParameter(Names, Angles) as IList;

        for (int i = 0; i < numberofASVs; i++)
        {

            ASVNum = System.Convert.ToInt32(ASV_Order[i]);
            ASVNum += 1;
            temp = "ASV " + ASVNum.ToString();
            if (Counter == 0)
            {
                TargetAngle = 0;
                Counter += 1;
            }

            else
            {
                TargetAngle = 360/(numberofASVs/Counter);
                Counter += 1;
            }

            ASVn = GameObject.Find(temp);
            var script = ASVn.GetComponent<ASVController>();
            script.TargetAngle = TargetAngle;
            script.ASVName = temp;
            script.MinDist = ObjSize;
            
            Debug.Log(ASVNum + ", " + TargetAngle);

        }

    }
}