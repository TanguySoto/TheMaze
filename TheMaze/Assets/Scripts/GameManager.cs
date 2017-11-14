﻿using UnityEngine;
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
		BeginGame();
	}
	
	private void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			RestartGame();
		}
	}


	// ============ METHODS

	private void BeginGame () {
		//mazeInstance = Instantiate(mazePrefab) as Maze;
		//mazeInstance.Generate();
		//player.SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates ()),true);
	}

	private void RestartGame () {
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}
}
