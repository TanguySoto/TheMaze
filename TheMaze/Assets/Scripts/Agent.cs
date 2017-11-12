using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	NavMeshAgent a;

	// Use this for initialization
	void Start () {
		a = GetComponentInChildren<NavMeshAgent> ();
		a.SetDestination (new Vector3 (5, 0, 5));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
