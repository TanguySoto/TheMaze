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

		// Color all children
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			if (child != hinge) {
				child.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
			}
		}
	}

	public override void OnPlayerEntered(){
		// room other side
		OtherSideOfDoor ().cell.room.Show ();

		// door itself
		OtherSideOfDoor ().hinge.gameObject.SetActive (false);
		hinge.gameObject.SetActive (false);
	}

	public override void OnPlayerExited(){
		hinge.gameObject.SetActive (true);
		OtherSideOfDoor ().hinge.gameObject.SetActive (true);

		//OtherSideOfDoor ().cell.room.Hide ();
	}
}