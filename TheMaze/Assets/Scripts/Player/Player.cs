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

public class Player : MonoBehaviour {

	// ============ VARIABLES

	public MazeCell currentCell;

	private  PlayerCollision pc;

	// ============ LIFECYCLE

	private void Start () {
		pc = GetComponent<PlayerCollision> ();
	}

	void OnControllerCollisionHit(ControllerColliderHit hit){
		pc.OnControllerColliderHit (hit);
	}

	// ============ METHODS

	public void SetLocation (MazeCell cell, bool movePlayer) {
		MazeCell previousCell = currentCell;
		currentCell = cell;
		if (movePlayer) {
			transform.localPosition = currentCell.transform.position + Vector3.up * 5;
		}
			
		if (previousCell != null) {
			previousCell.OnPlayerExited ();
		}
		currentCell.OnPlayerEntered ();
	}
}