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

public class SimpleAgent : MonoBehaviour {

	// ============ VARIABLES

	// Agent properties
	[Range(0,100)]
	public float health;
	[Range(0,1)]
	public float agressivity;

	protected NavMeshAgent mNavMeshAgent;

	// Maze
	public Maze maze;

	// States
	public enum STATES {SEARCHING, WALKING, FIGHTING};
	public STATES state = STATES.SEARCHING;

	// Targets
	public MazeCell walkingTarget;
	public GameObject targetToKill;

	// Agent caracteristics
	public float FIGHTING_DISTANCE = 1000.0f;
	public float DAMAGE = 2.0f;
	public float RANGE_DAMAGE = 0.5f;
	public float TIME_BETWEEN_ATTACKS = 2.0f; // 1 attack every TIME_BETWEEN_ATTACKS seconds
	public float TIME_BETWEEN_ANIMATIONS = 0.2f;

	float time_last_attack = -1;

	// ============ LIFECYCLE

	// Use this for initialization
	void Start () {
		mNavMeshAgent = GetComponent<NavMeshAgent> ();

		FIGHTING_DISTANCE = 3.0f;
		DAMAGE = 2.0f;
		RANGE_DAMAGE = 0.5f;
		TIME_BETWEEN_ATTACKS = 0.5f; // 1 attack every TIME_BETWEEN_ATTACKS seconds
		TIME_BETWEEN_ANIMATIONS = 0.2f;

		time_last_attack = -1;
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

		//if (Input.GetKeyDown(KeyCode.F)) {
		//	followPath ();	
		//}
	}




	// ============ METHODS

	protected void findPath(){
		// Find a random target
		MazeRoom r = maze.rooms [Random.Range (0, maze.rooms.Count)];
		MazeCell c = r.cells [Random.Range (0, r.cells.Count)];
		walkingTarget = c;

		state = STATES.WALKING;
	}


	protected void followPath(){
		// Going for its destination
		mNavMeshAgent.SetDestination (walkingTarget.transform.position);

		// If the goal has been reached, set state SEARCHING
		if (!mNavMeshAgent.pathPending){
			if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance){
				if (!mNavMeshAgent.hasPath || mNavMeshAgent.velocity.sqrMagnitude == 0f){
					state = STATES.SEARCHING;
				}
			}
		}
			
		// If the player is in front of the agent, set state FIGHTING
		// TODO
	}




	protected void fight(){
		// Check the distance between the agent and its target

		// Close enough
		if (Vector3.Distance (transform.position, targetToKill.transform.position) <= FIGHTING_DISTANCE) {
			if (mNavMeshAgent.hasPath) {
				mNavMeshAgent.ResetPath ();
			}
			attack ();
		}

		// Not close enough
		else {
			// Gets closer to the target
			mNavMeshAgent.SetDestination (targetToKill.transform.position);
		}

	}



	protected void attack(){
		if (time_last_attack == -1 || Time.time - time_last_attack >= TIME_BETWEEN_ATTACKS) {
			//StartCoroutine(fightSpearMovement());
			GameObject spear = this.transform.GetChild(2).gameObject; // 2nd child needs to be the spear
			Animation anim = spear.GetComponent<Animation> ();
			anim ["SpearAnimation"].speed = (1.0f / TIME_BETWEEN_ATTACKS) + TIME_BETWEEN_ANIMATIONS;
			anim.Play ("SpearAnimation");
			targetToKill.GetComponent<Player>().health -= DAMAGE;
			time_last_attack = Time.time;
		}
	}


}
