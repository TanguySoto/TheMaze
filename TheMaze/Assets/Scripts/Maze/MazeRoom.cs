using UnityEngine;
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

public class MazeRoom : MonoBehaviour {

	public int settingsIndex;

	public MazeRoomSettings settings;
	
	public List<MazeCell> cells = new List<MazeCell>();
	
	public void Add (MazeCell cell) {
		cell.room = this;
		cells.Add(cell);
	}

	public void Hide () {
		for (int i = 0; i < cells.Count; i++) {
			cells[i].Hide();
		}
	}

	public void Show () {
		for (int i = 0; i < cells.Count; i++) {
			cells[i].Show();
		}
	}
}