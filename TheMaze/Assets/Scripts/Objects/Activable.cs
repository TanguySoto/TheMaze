using UnityEngine;
using System.Collections;

public abstract class Activable : MonoBehaviour {

	protected GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public abstract void action ();
}
