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

	public bool mustGenerateLevel;

	public GameObject environment;
	public Maze mazePrefab;
	private Maze mazeInstance;

	public Player player;

	// ============ LIFECYCLE

	private void Start () {
		if(mustGenerateLevel){
			GenerateNewLevel();
		}
	}
	
	private void Update () {
		if (Input.GetKeyDown(KeyCode.N)) {
			Destroy (GameObject.Find ("West"));
			Destroy (GameObject.Find ("North"));
			Destroy (GameObject.Find ("East"));
			Destroy (GameObject.Find ("South"));
			GenerateNewLevel ();
		}
	}


	// ============ METHODS

	private void GenerateNewLevel () {
		// West
		// place and generate maze
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.transform.parent = environment.transform;
		mazeInstance.transform.localPosition = new Vector3 (225, 14.3f, 75);
		mazeInstance.doorProbability = 0.1f;
		mazeInstance.openRoom = true;
		mazeInstance.Generate();
		mazeInstance.name = "West";
		// open entrance
		for (int i = 0; i < mazeInstance.GetCell (new IntVector2 (0, 9)).transform.childCount; i++) {
			GameObject c = mazeInstance.GetCell (new IntVector2 (0, 9)).transform.GetChild (i).gameObject;
			if (c.GetComponent<MazeWall>()!=null) {
				Destroy (c);
			}
		}
		// show entrance room
		mazeInstance.GetCell(new IntVector2 (0, 9)).room.Show();

		// North
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.transform.parent = environment.transform;
		mazeInstance.transform.localPosition = new Vector3 (75, 14.3f, -75);
		mazeInstance.doorProbability = 0;
		mazeInstance.openRoom = false;
		mazeInstance.Generate();
		mazeInstance.name = "North";
		for (int i = 0; i < mazeInstance.GetCell (new IntVector2 (9, 19)).transform.childCount; i++) {
			GameObject c = mazeInstance.GetCell (new IntVector2 (9, 19)).transform.GetChild (i).gameObject;
			if (c.GetComponent<MazeWall>()!=null) {
				Destroy (c);
			}
		}
		mazeInstance.GetCell(new IntVector2 (9, 19)).room.Show();
			
		// East
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.transform.parent = environment.transform;
		mazeInstance.transform.localPosition = new Vector3 (-75, 14.3f, 75);
		mazeInstance.doorProbability = 0.1f;
		mazeInstance.openRoom = false;
		mazeInstance.Generate();
		mazeInstance.name = "East";
		for (int i = 0; i < mazeInstance.GetCell (new IntVector2 (19, 9)).transform.childCount; i++) {
			GameObject c = mazeInstance.GetCell (new IntVector2 (19, 9)).transform.GetChild (i).gameObject;
			if (c.GetComponent<MazeWall>()!=null) {
				Destroy (c);
			}
		}
		mazeInstance.GetCell(new IntVector2 (19, 9)).room.Show();

		// South
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.transform.parent = environment.transform;
		mazeInstance.transform.localPosition = new Vector3 (75, 14.3f, 225);
		mazeInstance.doorProbability = 0.03f;
		mazeInstance.openRoom = true;
		mazeInstance.Generate();
		mazeInstance.name = "South";
		for (int i = 0; i < mazeInstance.GetCell (new IntVector2 (9, 0)).transform.childCount; i++) {
			GameObject c = mazeInstance.GetCell (new IntVector2 (9, 0)).transform.GetChild (i).gameObject;
			if (c.GetComponent<MazeWall>()!=null) {
				Destroy (c);
			}
		}
		mazeInstance.GetCell(new IntVector2 (9, 0)).room.Show();
	}
}
