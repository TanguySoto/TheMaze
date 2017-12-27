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

public abstract class MazeCellEdge : MonoBehaviour {

	// ============ VARIABLES

	public MazeCell cell, otherCell;
	
	public MazeDirection direction;


	// ============ METHODS

	public virtual void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		this.cell = cell;
		this.otherCell = otherCell;
		this.direction = direction;
		
		cell.SetEdge(direction, this);
		transform.parent = cell.transform;
		transform.localPosition = Vector3.zero;
		transform.localRotation = direction.ToRotation();
	}

	public virtual void OnPlayerEntered(){}

	public virtual void OnPlayerExited(){}

	public virtual void hide(){}

	public virtual void show(){}
}