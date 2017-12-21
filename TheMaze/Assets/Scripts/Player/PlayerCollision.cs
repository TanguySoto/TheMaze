using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/*
 * Project EVIJV : "The Maze"
 * UPMC 2017/2018
 * 
 * Nicolas BILLOD
 * Tanguy SOTO
 * 
 * Modified from : https://forum.unity.com/threads/possible-to-sense-exit-of-oncontrollercolliderhit-controllercolliderhit-hit.248309/
 */

public class PlayerCollision : MonoBehaviour{

	public bool ManuallySet = false;

	private List<Collider> _stayedColliders = new List<Collider>();
	private List<Collider> _enteredColliders = new List<Collider>();

	private Player p;

	protected void Start(){
		p = GetComponent<Player> ();
	}

	void Update()
	{
		if (ManuallySet) return;

		this.Resolve();
	}

	public void Resolve()
	{
		//reimplement this so that we have all the hit information
		var entered = _enteredColliders.Except(_stayedColliders).ToArray();
		//var stayed = _stayedColliders.Intersect(_enteredColliders).ToArray();
		var exited = _stayedColliders.Except(_enteredColliders).ToArray();

		foreach (var c in entered)
		{
			if (!_stayedColliders.Contains (c)) {
				_stayedColliders.Add (c);
			}

			// notify collision entered
			if (c.transform.parent!=null && c.transform.parent.gameObject.GetComponent<MazeCell>()!=null) {
				MazeCell mc = c.transform.parent.gameObject.GetComponent<MazeCell> ();
				p.SetLocation (mc,false);
			}
		}

		/*
		foreach (var c in stayed)
		{
			// notify collision stayed
		}
		*/
			
		foreach (var c in exited)
		{
			_stayedColliders.Remove(c);

			// notify collision exited
		}

		_enteredColliders.Clear();
	}

	public void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (!_enteredColliders.Contains (hit.collider)) {
			_enteredColliders.Add (hit.collider);
		}
	}
}