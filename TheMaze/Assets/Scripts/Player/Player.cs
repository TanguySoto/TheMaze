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
	[Range(0,100)]
	public float health;

	public MazeCell currentCell;

	private  PlayerCollision pc;


	// ============ LIFECYCLE

	private void Start () {
		pc = GetComponent<PlayerCollision> ();
	}

	public void Update(){}

	void OnControllerCollisionHit(ControllerColliderHit hit){
		pc.OnControllerColliderHit (hit);
	}

	// ============ METHODS

	public void SetLocation (MazeCell cell, bool movePlayer) {
		MazeCell previousCell = currentCell;
		currentCell = cell;
		if (movePlayer) {
			transform.localPosition = currentCell.transform.position + Vector3.up;
		}
			
		if (previousCell != null) {
			previousCell.OnPlayerExited ();
		}
		currentCell.OnPlayerEntered ();
	}



}