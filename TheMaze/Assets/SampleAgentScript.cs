using UnityEngine;
using System.Collections;

public class SampleAgentScript : MonoBehaviour {


	public Transform target;
	NavMeshAgent agent;
	bool end;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.Find ("FloorTest").transform;
		end = false;
	}

	// Update is called once per frame
	void Update () {
		
		if (end == true) {
			target = GameObject.Find ("FloorTest2").transform;
		}
		agent.SetDestination (target.position);

		if (!agent.pathPending)
		{
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					end = true;
				}
			}
		}

	}
}
