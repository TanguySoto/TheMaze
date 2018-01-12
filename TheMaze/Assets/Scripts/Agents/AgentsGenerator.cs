using UnityEngine;
using System.Collections;

public class AgentsGenerator : MonoBehaviour {

	public Maze laby;
	public NavMesh nm;
	public GameObject agentPrefab;

	public int MAX_AGENTS;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		createAgents ();
	}

	protected void createAgents(){
		int nbAgents = this.transform.childCount;

		for (int i = nbAgents; i < MAX_AGENTS; i++) {
			GameObject o = Instantiate (agentPrefab) as GameObject;
			o.name = "Agent";
			SimpleAgent a = o.GetComponent<SimpleAgent> ();
			a.transform.parent = this.transform;
			a.maze = laby;
			chooseStartLocation (a);
		}
	}

	protected void chooseStartLocation(SimpleAgent a){
		MazeRoom r = laby.rooms [Random.Range (0, laby.rooms.Count)];
		MazeCell c = r.cells [Random.Range (0, r.cells.Count)];

		a.transform.localPosition = new Vector3 (c.transform.position.x, 52f, c.transform.position.z);
	}
}
