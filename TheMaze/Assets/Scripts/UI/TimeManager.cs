using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * Project EVIJV : "The Maze"
 * UPMC 2017/2018
 * 
 * Nicolas BILLOD
 * Tanguy SOTO
 * 
 */

public class TimeManager : MonoBehaviour {

	public Text text;
	public Light mLight;
	public GameObject agents;

	protected float DAYDURATION = 60;
	protected float time;
	protected bool isDay = true;
	protected bool switched = false;

	// Use this for initialization
	void Start () {
		time = DAYDURATION;
	}
	
	// Update is called once per frame
	void Update () {

		// update time value
		time = time - Time.deltaTime;

		if (time <= 0) {
			time = DAYDURATION;
			switched = false;
		}

		if (time <= DAYDURATION*3.0/4.0 && !switched) {
			isDay=!isDay;
			updateAgents ();
			switched = true;
		}

		// update UI
		if (isDay) {
			if (time >= DAYDURATION *3.0/ 4.0) {
				mLight.intensity -= Time.deltaTime / (DAYDURATION/4.0f);
			}
			text.text = "Day";

		} else {
			if (time >= DAYDURATION *3.0/ 4.0) {
				mLight.intensity += Time.deltaTime / (DAYDURATION/4.0f);
			}
			text.text = "Night";
		}
	}

	protected void updateAgents(){
		// Aggressivity
		for (int i = 0; i < agents.transform.childCount; i++) {
			if(isDay){
				agents.transform.GetChild (i).GetComponent<SimpleAgent> ().agressivity = 0.4f;
			}
			else {
				agents.transform.GetChild (i).GetComponent<SimpleAgent> ().agressivity = 1;
			}
		}
	}
}
