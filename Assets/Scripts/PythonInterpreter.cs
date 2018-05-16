using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

public class PythonInterpreter : MonoBehaviour
{

	public static IList PatchParameter(IList Names, IList Angles)
	{
		//List<int> Filler = new List<int>();

	    Debug.Log(Names.Count);

		//List<IList> ASV_Data = new List<IList>();

		//ASV_Data[0][0]=9;
		double[,] ASV_Data = new double[Names.Count,4];

		double temp;
		for (int i = 0; i < Names.Count; i++)
		{
			temp = Convert.ToDouble(Angles[i]);
			ASV_Data[i,0]=i;
			ASV_Data[i,1]=0;
			ASV_Data[i,2]=0;
			ASV_Data[i,3]=temp;
		}


		foreach(object obj1 in ASV_Data)
    	{
    		Debug.Log(obj1);
    	}

		/*ASV_Data.Add(Names);
		ASV_Data.Add(Filler);
		ASV_Data.Add(Filler);
		ASV_Data.Add(Angles);*/

	    //Debug.Log(ASV_Data.Count);
		
	    var engine = Python.CreateEngine(); // Extract Python language engine from their grasp
	    var scope = engine.CreateScope(); // Introduce Python namespace (scope)

	    scope.SetVariable("ASV_Data_array", ASV_Data);
	    //ScriptSource source = engine.CreateScriptSourceFromFile("/Users/ABWoodman/Documents/test.py"); // Load the script
	    ScriptSource source = engine.CreateScriptSourceFromFile("/Users/ABWoodman/Documents/Pos_All_Final.py"); // Load the script
	    var compiledScript = source.Compile();
	    compiledScript.Execute(scope);
	    object ASV_Location = scope.GetVariable("ASV_Allocation"); // To get the finally set variable 'parameter' from the python script

	    //Debug.Log(ASV_Location.Length);

	    IList ASV_Final = ASV_Location as IList;

		foreach(object obj in ASV_Final)
    	{
    		Debug.Log(obj);
    	}
	    //Debug.Log(ASV_Final.Count);

	    return ASV_Final;
	}
}