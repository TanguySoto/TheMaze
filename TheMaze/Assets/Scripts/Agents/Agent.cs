using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Project EVIJV : "The Maze"
 * UPMC 2017/2018
 * 
 * Nicolas BILLOD
 * Tanguy SOTO
 * 
 */

public class Agent : MonoBehaviour {

	// ============ VARIABLES

	// Agent properties
	[Range(0,100)]
	public float health;
	[Range(0,1)]
	public float agressivity;

	// Path finding
	public Maze maze;
	public MazeCell position;
	public MazeCell target;
	public List<MazeCell> path;

	protected NavMeshAgent a;

	// States
	public enum STATES {SEARCHING, WALKING, FIGHTING};
	public STATES state = STATES.SEARCHING;


	// ============ LIFECYCLE

	// Use this for initialization
	void Start () {
		a = GetComponentInChildren<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		switch (state) {
		case STATES.SEARCHING:
			findPath ();
			break;
		case STATES.WALKING:
			followPath ();
			break;
		case STATES.FIGHTING:
			fight ();
			break;
		default:
			break;
		}

		if (Input.GetKeyDown(KeyCode.F)) {
			followPath ();	
		}
	}




	// ============ METHODS

	protected void findPath(){
		// Find a random target
		MazeRoom r = maze.rooms [Random.Range (0, maze.rooms.Count)];
		MazeCell c = r.cells [Random.Range (0, r.cells.Count)];
		target = c;

		// Calculate path from position to target (BFS in O(n+m))
		path = new List<MazeCell> ();

		Dictionary<MazeCell,MazeCell> fathers = new Dictionary<MazeCell,MazeCell> ();
		Queue q = new Queue();
		q.Enqueue (position);
		fathers.Add (position, null);
		MazeCell curr = null;

		while (curr != target && q.Count > 0) {
			curr = (MazeCell) q.Dequeue ();
			foreach (MazeCellEdge e in curr.edges) {
				if (e is MazePassage && !fathers.ContainsKey(e.otherCell)) {
					fathers.Add (e.otherCell, curr);
					q.Enqueue (e.otherCell);
				}
			}
		}

		// No Path found
		if (curr != target) {
			//
		} 
		// Path found
		else {
			while (curr!=null) {
				path.Add (curr);
				curr = fathers [curr];
			}
			path.Reverse ();
			a.SetDestination (path[0].gameObject.transform.GetChild(0).position);
			path.RemoveAt (0);
			state = STATES.WALKING;
		}
	}

	protected void followPath(){
		if (a.destination.x == this.transform.position.x && a.destination.z == this.transform.position.z) {
			if (path.Count > 0) {
				MazeCell next = path [0];
				path.RemoveAt (0);

				a.SetDestination (next.gameObject.transform.GetChild(0).position);
			} else {

				state = STATES.SEARCHING;
			}
		} else {
			Debug.Log (a.destination+" - "+this.transform.position);
		}
	}

	protected void fight(){

	}
}
