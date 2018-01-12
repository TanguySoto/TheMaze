using UnityEngine;
using System.Collections;

public class Lock : Activable {

	public GameObject keyPrefab;
	public bool isLocked = true;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void Unlock(){
		isLocked = false;
		GameObject.Find ("Exit").GetComponent<Exit> ().addUnlockedLock ();
	}

	private void Lock_(){
		isLocked = true;
		GameObject.Find ("Exit").GetComponent<Exit> ().removeUnlockedLock ();
	}

	public override void action(){
		Player p = player.GetComponent<Player> ();

		if (p.keys > 0) {
			p.keys--;

			GameObject key = GameObject.Instantiate (keyPrefab) as GameObject;
			key.name = "ActivatedKey";
			key.transform.parent = GameObject.Find ("Environment").transform;
			key.transform.position = this.transform.position + new Vector3 (0, 1, 0);
			key.transform.localScale = new Vector3 (key.transform.localScale.x, 0.25f, key.transform.localScale.z);
			key.GetComponent<LineRenderer> ().enabled = false;

			Key k = key.GetComponent<Key> ();
			k.isOnLock = true;

			Behaviour h = (Behaviour)key.GetComponent("Halo");
			h.enabled = true;

			Unlock ();
		}
	}
}
