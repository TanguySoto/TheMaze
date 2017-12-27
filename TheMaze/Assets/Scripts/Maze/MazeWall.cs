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

public class MazeWall : MazeCellEdge {
	public Transform wall;

	public override void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		base.Initialize(cell, otherCell, direction);
		wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
	}

	public override void show(){
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).GetComponent<Renderer> ().enabled = true;
		}
	}

	public override void hide(){
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).GetComponent<Renderer> ().enabled = false;
		}
	}
}