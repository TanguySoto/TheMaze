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
	private int initializedEdgeCount;

	public IntVector2 coordinates;

	private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

	// ============ LIFECYCLE

	private void Start () {}
	
	private void Update () {}


	// ============ METHODS


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
}
