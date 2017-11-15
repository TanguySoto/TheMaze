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

public class GameManager : MonoBehaviour {

	// ============ VARIABLES

	public Maze mazePrefab;
	private Maze mazeInstance;

	public Player player;

	// ============ LIFECYCLE

	private void Start () {
		//GenerateNewLaby();
		//applyPatch();
	}
	
	private void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			RestartGame();
		}
	}


	// ============ METHODS

	private void GenerateNewLaby () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.Generate();
	}

	private void applyPatch(){
		Maze[] mazes = new Maze[4];
		mazes [0] = GameObject.Find ("West").GetComponent<Maze> ();
		mazes[1] = GameObject.Find ("North").GetComponent<Maze> ();
		mazes[2] = GameObject.Find ("South").GetComponent<Maze> ();
		mazes[3] = GameObject.Find ("East").GetComponent<Maze> ();

		Material newMat = Resources.Load("Materials/Wall1",typeof(Material)) as Material;

		// update every maze
		foreach (Maze m in mazes) {
			// update every room
			foreach (MazeRoom room in m.rooms) {
				// update wall and door material of room 1
				if(room.settingsIndex==0){
					foreach (MazeCell c in room.cells) {
						MazeWall[] walls = c.transform.gameObject.GetComponentsInChildren<MazeWall> ();
						foreach (MazeWall w in walls) {
							if (w.wall) {
								w.wall.gameObject.GetComponent<Renderer> ().material = newMat;
							}
						}
						MazeDoor[] doors = c.transform.gameObject.GetComponentsInChildren<MazeDoor> ();
						foreach (MazeDoor d in doors) {
							foreach (Renderer r in d.GetComponentsInChildren<Renderer>()) {
								if (r != d.hinge.GetComponentInChildren<Renderer> ()) {
									r.material = newMat;
								}
							}
						}
					}
				}

				// update all door height
				foreach (MazeCell c in room.cells) {
					MazeDoor[] doors = c.transform.gameObject.GetComponentsInChildren<MazeDoor> ();
					foreach (MazeDoor d in doors) {
						d.GetComponentsInChildren<Transform> () [2].localScale = new Vector3 (1, 0.02f, 0.05f);
						d.GetComponentsInChildren<Transform> () [2].localPosition = new Vector3 (0, 0.01f, 0.475f);
						d.hinge.transform.localPosition = new Vector3 (d.hinge.transform.localPosition.x, 0.02f, d.hinge.transform.localPosition.z);

						Transform left = d.GetComponentsInChildren<Transform> () [3];
						left.localPosition = new Vector3 (left.localPosition.x, 0.37f, left.localPosition.z);
						Transform right = d.GetComponentsInChildren<Transform> () [4];
						right.localPosition = new Vector3 (right.localPosition.x, 0.37f, right.localPosition.z);
					}
				}

			}
		}
	}

	private void RestartGame () {
		Destroy(mazeInstance.gameObject);
		GenerateNewLaby();
	}
}
