using UnityEngine;

/*
 * Project EVIJV : "The Maze"
 * UPMC 2017/2018
 * 
 * Nicolas BILLOD
 * Tanguy SOTO
 * 
 * Inspired by : http://catlikecoding.com/unity/tutorials/maze/
 */

public class MazeDoor : MazePassage {
	
	public Transform hinge;

	private MazeDoor OtherSideOfDoor() {
		return otherCell.GetEdge(direction.GetOpposite()) as MazeDoor;
	}
	
	public override void Initialize (MazeCell primary, MazeCell other, MazeDirection direction) {
		base.Initialize(primary, other, direction);
		// Reverse door if there is already one behind to that handles are same side
		if (OtherSideOfDoor() != null) {
			hinge.localScale = new Vector3(-1f, 1f, 1f);
			Vector3 p = hinge.localPosition;
			p.x = -p.x;
			hinge.localPosition = p;
		}

		// Color all children
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			if (child != hinge) {
				child.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
			}
		}
	}

	public override void OnPlayerEntered(){
		OtherSideOfDoor ().cell.room.Show ();

		OtherSideOfDoor ().hinge.gameObject.SetActive (false);
		hinge.gameObject.SetActive (false);
	}

	public override void OnPlayerExited(){
		hinge.gameObject.SetActive (true);
		OtherSideOfDoor ().hinge.gameObject.SetActive (false);

		//OtherSideOfDoor ().cell.room.Hide ();
	}
}