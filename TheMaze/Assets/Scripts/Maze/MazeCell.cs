using UnityEngine;
using System.Collections;

/*
 * Project EVIJV : "The Maze"
 * UPMC 2017/2018
 * 
 * Nicolas BILLOD
 * Tanguy SOTO
 * 
 * Inspired by : http://catlikecoding.com/unity/tutorials/maze/
 */

public class MazeCell : MonoBehaviour {

	// ============ VARIABLES
	public int initializedEdgeCount;

	public IntVector2 coordinates;

	public MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

	public MazeRoom room;

	public int playerStepsCounter;
	

	// ============ LIFECYCLE

	private void Start () {}
	
	private void Update () {}


	// ============ METHODS

	public void Initialize (MazeRoom room) {
		room.Add(this);
		transform.GetChild(0).GetComponent<Renderer>().material = room.settings.floorMaterial;
	}

	public MazeCellEdge GetEdge (MazeDirection direction) {
		return edges[(int)direction];
	}

	public bool IsFullyInitialized() {
		return initializedEdgeCount == MazeDirections.Count;
	}
	
	public void SetEdge (MazeDirection direction, MazeCellEdge edge) {
		edges[(int)direction] = edge;
		initializedEdgeCount += 1;
	}

	public MazeDirection RandomUninitializedDirection() {
		int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
		for (int i = 0; i < MazeDirections.Count; i++) {
			if (edges[i] == null) {
				if (skips == 0) {
					return (MazeDirection)i;
				}
				skips -= 1;
			}
		}
		throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
	}

	public void OnPlayerEntered () {
		for (int i = 0; i < edges.Length; i++) {
			if (edges [i] != null) {
				edges [i].OnPlayerEntered ();
			}
		}
		room.Show();
	}

	public void OnPlayerExited () {
		for (int i = 0; i < edges.Length; i++) {
			if (edges [i] != null) {
				edges [i].OnPlayerExited ();
			}
		}
		room.Hide();
	}

	public void Show () {
		// floor
		this.transform.GetChild (0).GetComponent<Renderer> ().enabled = true;

		// edges
		for (int i = 0; i < edges.Length; i++) {
			if (edges [i] != null) {
				edges [i].show ();
			}
		}
	}

	public void Hide () {
		// floor
		this.transform.GetChild (0).GetComponent<Renderer> ().enabled = false;

		// edges
		for (int i = 0; i < edges.Length; i++) {
			if (edges [i] != null) {
				edges [i].hide ();
			}
		}
	}
}
