using UnityEngine;
using System.Collections;

/*
 * Project EVIJV : "The Maze"
 * UPMC 2017/2018
 * 
 * Nicolas BILLOD
 * Tanguy SOTO
 * 
 */

public static class MyDebug {

	public static void Log(MonoBehaviour caller, string message){
		Debug.Log(System.DateTime.Now.Hour+":"+System.DateTime.Now.Minute+":"+System.DateTime.Now.Second+
			"."+System.DateTime.Now.Millisecond+" - "+caller.name+" : "+message);
	}
}
