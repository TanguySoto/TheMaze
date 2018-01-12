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

public class AgentHealthBar : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// Must look at the player
		Quaternion angle = Quaternion.LookRotation (player.transform.position - this.transform.position);
		transform.rotation=Quaternion.Slerp (transform.rotation, angle, Time.deltaTime * 3);
	}
}
