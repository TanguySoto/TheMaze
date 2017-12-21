using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public GameObject associatedWall;
	public int unLockedLocks = 0;

	// Use this for initialization
	void Start () {
		LineRenderer l = this.GetComponent<LineRenderer> ();
		l.SetPosition (0, this.transform.position +  new Vector3 (0, 0.4f, 0));
		l.SetPosition (1, this.transform.position + new Vector3 (0, 200, 0));
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void addUnlockedLock(){
		unLockedLocks++;
		if (unLockedLocks >= 4) {
			open ();
		}
	}

	public void removeUnlockedLock(){
		unLockedLocks--;
		if (unLockedLocks < 4) {
			close ();
		}
	}

	protected void open(){
		LineRenderer l = this.GetComponent<LineRenderer> ();
		l.SetColors (Color.green, Color.green);
		associatedWall.SetActive (false);
	}

	protected void close(){
		LineRenderer l = this.GetComponent<LineRenderer> ();
		Color red = new Color (1, 0.1f, 0.1f);
		l.SetColors (red,red);
		associatedWall.SetActive (true);
	}
}
