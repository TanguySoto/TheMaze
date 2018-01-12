using UnityEngine;
using System.Collections;

public class Key : Activable {

	public bool isOnLock = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		LineRenderer l = this.GetComponent<LineRenderer> ();
		l.SetPosition (0, this.transform.position +  new Vector3 (0, 0.4f, 0));
		l.SetPosition (1, this.transform.position +  new Vector3 (0, 200, 0));
	}
	
	// Update is called once per frame
	void Update () {
	}

	public override void action(){
		if (!isOnLock) {
			Player p = player.GetComponent<Player> ();
			p.keys++;
			Destroy (this.gameObject);
		}
	}
}
