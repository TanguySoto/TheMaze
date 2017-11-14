using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	NavMeshAgent a;

	// Use this for initialization
	void Start () {
		a = GetComponentInChildren<NavMeshAgent> ();
		a.destination = GameObject.Find ("Player").transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (a.destination);
	}
}
