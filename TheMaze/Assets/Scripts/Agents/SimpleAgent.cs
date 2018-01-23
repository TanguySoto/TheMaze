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

public class SimpleAgent : Activable {

	// ============ VARIABLES

	// Agent properties
	[Range(0,100)]
	public float health;
	[Range(0.1f,1)]
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
	public float VIEW_ANGLE;
	public float FIGHTING_ANGLE;
	public float UNDETECTING_DISTANCE;
	public float DETECTING_DISTANCE;
	public float FIGHTING_DISTANCE;
	public float DAMAGE;
	public float RANGE_DAMAGE;
	public float TIME_BETWEEN_ATTACKS; // 1 attack every TIME_BETWEEN_ATTACKS seconds
	public float TIME_BETWEEN_ANIMATIONS;
	public float ROTATION_SPEED;

	protected float time_last_attack = -1;

	// Materials
	public Material greenMat;
	public Material redMat;

	// ============ LIFECYCLE

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		targetToKill = player;

		mNavMeshAgent = GetComponent<NavMeshAgent> ();
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
	}
		

	// ============ METHODS

	public override void action(){
		getAttacked ();

	}

	protected void getAttacked(){
		Player p = targetToKill.GetComponent<Player> ();
		if (p.time_last_attack == -1 || Time.time - p.time_last_attack >= p.TIME_BETWEEN_ATTACK) {
			Animation anim = targetToKill.transform.GetChild(1).GetChild(1).GetComponent<Animation> ();
			anim ["SpearAnimation"].speed = (1.0f / (p.TIME_BETWEEN_ATTACK) + TIME_BETWEEN_ANIMATIONS);
			anim.Play ("SpearAnimation");

			// Actual damage
			float damage = (p.DAMAGE+Random.Range(0,p.RANGE_DAMAGE));
			if (health > damage) {
				health -= damage;

				// update health bar
				GameObject bar = this.transform.GetChild(4).gameObject;
				bar.transform.localScale = new Vector3(health*0.015f, bar.transform.localScale.y, bar.transform.localScale.z);

				this.transform.GetChild (0).gameObject.GetComponent<Renderer> ().material = redMat;
				state = STATES.FIGHTING;
				p.time_last_attack = Time.time;
			} else {
				onDie ();
			}
		}
	}

	public void onDie (){
		Destroy (this.gameObject);
	}

	protected void findPath(){
		// Select a random room
		MazeRoom r = maze.rooms [Random.Range (0, maze.rooms.Count)];

		float randomNumber = Random.Range (0.0f, 1.0f);

		// Number of total steps
		int nbSteps = 0;
		foreach (MazeCell c in r.cells) {
			nbSteps += c.playerStepsCounter + 1;
		}


		// Look for the cell to go to
		float cpt = 0.0f;
		foreach (MazeCell c in r.cells){	
			if (randomNumber >= cpt && randomNumber <= cpt + ((c.playerStepsCounter + 1)*1.0f / nbSteps)){
				walkingTarget = c;
				break;
			}
			cpt += (c.playerStepsCounter + 1)*1.0f / nbSteps;
		}

		//walkingTarget = c;

		state = STATES.WALKING;
	}
		
	protected void followPath(){
		// Going for its destination
		mNavMeshAgent.SetDestination (walkingTarget.transform.position);

		// If the goal has been reached, set state SEARCHING
		if (!mNavMeshAgent.pathPending){
			if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance){
				if (!mNavMeshAgent.hasPath || mNavMeshAgent.velocity.sqrMagnitude == 0f){
					this.transform.GetChild (0).gameObject.GetComponent<Renderer> ().material = greenMat;
					state = STATES.SEARCHING;
				}
			}
		}
			
		// If the player is in front of the agent, set state FIGHTING
		detectPlayer();
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
			unDetectPlayer ();
		}
	}

	protected void detectPlayer(){
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, DETECTING_DISTANCE*agressivity);
		int i = 0;
		// Objects at right distance
		while (i < hitColliders.Length){
			if (hitColliders[i].gameObject==targetToKill) {
				// Objects in line of sight
				RaycastHit hit;
				Vector3 rayOrigin = this.transform.position+Vector3.up;
				Vector3 targetDirection = hitColliders[i].transform.position - this.transform.position;

				if (Physics.Raycast (rayOrigin, targetDirection, out hit)) {

					// Angle of sight
					float angle = Vector3.Angle (targetDirection, this.transform.forward);
					if (Mathf.Abs (angle) < VIEW_ANGLE*agressivity) {
						this.transform.GetChild (0).gameObject.GetComponent<Renderer> ().material = redMat;
						state = STATES.FIGHTING;
						return;
					}
				}				 
			}
			i++;
		}
	}

	protected void unDetectPlayer(){
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, UNDETECTING_DISTANCE*agressivity);
		int i = 0;
		// Objects at right distance
		while (i < hitColliders.Length){
			if (hitColliders[i].gameObject==targetToKill) {
				state = STATES.FIGHTING;
				return;
			}
			i++;
		}

		this.transform.GetChild (0).gameObject.GetComponent<Renderer> ().material = greenMat;
		state = STATES.SEARCHING;
	}

	protected void attack(){
		// Must look at the player
		Vector3 targetDirection = targetToKill.transform.position - this.transform.position;
		Quaternion angle = Quaternion.LookRotation (targetDirection);
		transform.rotation=Quaternion.Slerp (transform.rotation, angle, Time.deltaTime * ROTATION_SPEED);

		// Check if player is in front of the agent
		float diffAngle = Mathf.Abs(Vector3.Angle (targetDirection, this.transform.forward));

		if ((time_last_attack == -1 || Time.time - time_last_attack >= TIME_BETWEEN_ATTACKS) && (diffAngle < FIGHTING_ANGLE)) {
			// Animation
			GameObject spear = this.transform.GetChild(2).gameObject; // 3rd child needs to be the spear
			Animation anim = spear.GetComponent<Animation> ();
			anim ["SpearAnimation"].speed = (1.0f / (TIME_BETWEEN_ATTACKS) + TIME_BETWEEN_ANIMATIONS);
			anim.Play ("SpearAnimation");

			// Actual damage
			float damage = (DAMAGE*agressivity+Random.Range(0,RANGE_DAMAGE*agressivity));
			if (targetToKill.GetComponent<Player> ().health > damage) {
				targetToKill.GetComponent<Player> ().health -= damage;
				time_last_attack = Time.time;
			} else {
				targetToKill.GetComponent<Player> ().onDie ();
			}
		}
	}
}
