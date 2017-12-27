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
	public GameObject mapCamera;

	public GameObject leftTagPrefab;
	public GameObject rightTagPrefab;
	public GameObject warningTagPrefab;

	[Range(0,100)]
	public float health;

	[Range(0,4)]
	public int keys;

	public MazeCell currentCell;

	private  PlayerCollision pc;


	// ============ LIFECYCLE

	private void Start () {
		pc = GetComponent<PlayerCollision> ();
	}

	public void Update(){

		// Keyboard events
		if (Input.GetKeyDown (KeyCode.A)) {
			action ();
		} else if (Input.GetKeyDown (KeyCode.Alpha1)) {
			placeTagLeft ();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			placeTagRight ();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			placeTagWarning ();
		} else if (Input.GetKeyDown (KeyCode.R)) {
			removeTag ();
		} else if (Input.GetKeyDown (KeyCode.Tab)) {
			toggleMap ();
		}

		if (Input.GetKeyUp (KeyCode.Tab)) {
			toggleMap ();
		}

	}

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
			
		if (previousCell != null){
			previousCell.OnPlayerExited ();
		}
		currentCell.OnPlayerEntered ();
	}

	protected void action(){
		GameObject target = GameObject.Find ("Pointer").GetComponent<PointerManager> ().targetedObject;
		if (target!=null && target.GetComponent<Activable>()!=null) {
			Activable a = target.GetComponent<Activable>();
			a.action ();
		}
	}

	protected void placeTagLeft(){
		GameObject target = GameObject.Find ("Pointer").GetComponent<PointerManager> ().targetedObject;
		if (target!=null && target.GetComponentInParent<MazeWall>()!=null) {
			GameObject tag = Instantiate (leftTagPrefab) as GameObject;
			RaycastHit h = GameObject.Find ("Pointer").GetComponent<PointerManager> ().hitPoint;
			tag.transform.position = h.point + h.normal * 0.02f;
			tag.name = "Tag";
			tag.transform.localScale = new Vector3 (1, 0.5f, 1);
			tag.transform.localRotation = target.transform.parent.localRotation;
		}
	}

	protected void placeTagRight(){
		GameObject target = GameObject.Find ("Pointer").GetComponent<PointerManager> ().targetedObject;
		if (target!=null && target.GetComponentInParent<MazeWall>()!=null) {
			GameObject tag = Instantiate (rightTagPrefab) as GameObject;
			RaycastHit h = GameObject.Find ("Pointer").GetComponent<PointerManager> ().hitPoint;
			tag.transform.position = h.point + h.normal * 0.02f;
			tag.name = "Tag";
			tag.transform.localScale = new Vector3 (1, 0.5f, 1);
			tag.transform.localRotation = target.transform.parent.localRotation;
			tag.transform.Rotate (new Vector3 (0, 0, 180));
		}
	}

	protected void placeTagWarning(){
		GameObject target = GameObject.Find ("Pointer").GetComponent<PointerManager> ().targetedObject;
		if (target!=null && target.GetComponentInParent<MazeWall>()!=null) {
			GameObject tag = Instantiate (warningTagPrefab) as GameObject;
			RaycastHit h = GameObject.Find ("Pointer").GetComponent<PointerManager> ().hitPoint;
			tag.transform.position = h.point + h.normal * 0.02f;
			tag.name = "Tag";
			tag.transform.localScale = new Vector3 (1, 0.9f, 1);
			tag.transform.localRotation = target.transform.parent.localRotation;
		}
	}

	protected void removeTag(){
		GameObject target = GameObject.Find ("Pointer").GetComponent<PointerManager> ().targetedObject;
		if (target != null && target.name == "Tag") {
			Destroy (target);
		}
	}

	protected void toggleMap(){
		mapCamera.SetActive (!mapCamera.activeSelf);
	}
}