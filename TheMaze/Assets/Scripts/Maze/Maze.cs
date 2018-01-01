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
 * Inspired by : http://catlikecoding.com/unity/tutorials/maze/
 */

public class Maze : MonoBehaviour {

	// ============ VARIABLES

	public Vector3 scale;
	public IntVector2 size;
	[Range(0f, 1f)]
	public float doorProbability;
	public bool openRoom = false;
	public MazeRoomSettings[] roomSettings;
	
	public MazeWall[] wallPrefabs;
	public MazeCell cellPrefab;
	public MazePassage passagePrefab;
	public MazeDoor doorPrefab;
	public MazeRoom roomPrefab;
	
	public MazeCell[,] cells;
	public List<MazeRoom> rooms = new List<MazeRoom>();


	// ============ LIFECYCLE

	private void Start () {}
	
	private void Update () {}


	// ============ METHODS

	public void Generate () {
		cells = new MazeCell[size.x, size.z];

		// List of already generate cells we still didn't try to expand
		List<MazeCell> activeCells = new List<MazeCell>();
		DoFirstGenerationStep(activeCells);

		// While the is still a cell to expand
		while (activeCells.Count > 0) {
			DoNextGenerationStep(activeCells);
		}

		// Scale it
		gameObject.transform.localScale = scale;

		// Hide all rooms
		for (int i = 0; i < rooms.Count; i++) {
			rooms[i].Hide();
		}

		Debug.Log("Maze generated");
	}

	private void DoFirstGenerationStep (List<MazeCell> activeCells) {
		MazeCell newCell = CreateCell(RandomCoordinates());
		newCell.Initialize(CreateRoom(-1));
		activeCells.Add(newCell);
	}

	private void DoNextGenerationStep (List<MazeCell> activeCells) {
		// Get the last active cell to try to expand from it
		int currentIndex = activeCells.Count-1; //Random.Range(0,activeCells.Count);
		MazeCell currentCell = activeCells[currentIndex];

		// Cell is already fully expanded
		if (currentCell.IsFullyInitialized()) {
			activeCells.RemoveAt(currentIndex);
			return;
		}

		// Create neighbor from expansion
		MazeDirection direction = currentCell.RandomUninitializedDirection();
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
		// It is inside the maze
		if (ContainsCoordinates(coordinates)) {
			MazeCell neighbor = GetCell(coordinates);
			// Doesn't already exist
			if (neighbor == null) {
				neighbor = CreateCell(coordinates);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			}
			else if(currentCell.room == neighbor.room && openRoom){
				CreatePassageInSameRoom(currentCell,neighbor,direction);
			}
			// Already exists
			else {
				CreateWall(currentCell, neighbor, direction);
			}
		}
		// Outside maze
		else {
			CreateWall(currentCell, null, direction);
		}
	}

	// Create a room, avoiding to recreate the same as indexToExclude
	private MazeRoom CreateRoom (int indexToExclude) {
		MazeRoom newRoom = Instantiate (roomPrefab) as MazeRoom;
		newRoom.transform.parent = transform;
		newRoom.transform.position = Vector3.zero;
		newRoom.settingsIndex = Random.Range(0, roomSettings.Length);

		if (newRoom.settingsIndex == indexToExclude) {
			newRoom.settingsIndex = (newRoom.settingsIndex + 1) % roomSettings.Length;
		}
		newRoom.settings = roomSettings[newRoom.settingsIndex];
		rooms.Add(newRoom);

		return newRoom;
	}

	private void CreatePassageInSameRoom (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}

	private void CreatePassage (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage prefab = Random.value < doorProbability ? doorPrefab : passagePrefab;

		MazePassage passage = Instantiate(prefab) as MazePassage;
		passage.Initialize(cell, otherCell, direction);
		Vector3 localScale = new Vector3 (1,1,1);
		if (passage is MazeDoor) {
			passage.transform.localScale = localScale;
		}

		passage = Instantiate(prefab) as MazePassage;

		// create room different from the one of cell ...
		if (passage is MazeDoor) {
			passage.transform.localScale = localScale;
			otherCell.Initialize(CreateRoom(cell.room.settingsIndex));
		}
		// or add next cell to same room
		else {
			otherCell.Initialize(cell.room);
		}

		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}

	private void CreateWall (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazeWall wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
		wall.Initialize(cell, otherCell, direction);
		if (otherCell != null) {
			Vector3 localScale = new Vector3 (1,1,1);
			wall.transform.localScale = localScale;
			wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
			wall.transform.localScale = localScale;
		}
	}

	public IntVector2 RandomCoordinates() {
		return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
	}

	public bool ContainsCoordinates (IntVector2 coordinate) {
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
	}

	private MazeCell CreateCell (IntVector2 coordinates) {
		// Add new cell
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
		cells[coordinates.x, coordinates.z] = newCell;

		// Setup the cell
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " +coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);

		return newCell;
	}

	public MazeCell GetCell (IntVector2 coordinates) {
			return cells[coordinates.x, coordinates.z];
	}
}
