using UnityEngine;
using System.Collections;

public class Food : Activable {

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void action(){
		player.GetComponent<Player> ().health = 100;
	}
}
