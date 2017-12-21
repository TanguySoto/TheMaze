using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour {

	public Text text;
	public Light light;

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
			switched = true;
		}

		// update UI
		if (isDay) {
			if (time >= DAYDURATION *3.0/ 4.0) {
				light.intensity -= Time.deltaTime / (DAYDURATION/4.0f);
			}
			text.text = "Day ";
		} else {
			if (time >= DAYDURATION *3.0/ 4.0) {
				light.intensity += Time.deltaTime / (DAYDURATION/4.0f);
			}
			text.text = "Night";
		}
	}
}
