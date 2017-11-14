using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointerManager : MonoBehaviour {

	[Range(0,20)]
	public float maxInteractionDistance;

	public Text pointedName;
	public Camera fpsCamera;

	private GameObject targetedObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetPointedObject ();
	}

	public void GetPointedObject(){
		RaycastHit hit;

		Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 1.0f));
		if (Physics.Raycast (rayOrigin, fpsCamera.transform.forward, out hit)) {
			float distance = hit.distance;
			if (distance < maxInteractionDistance) {
				pointedName.text = hit.collider.gameObject.name + "";
				targetedObject = hit.collider.gameObject;
			} else {
				pointedName.text = "-";
			}
		}
		else {
			pointedName.text = "-";
		}
	}
}
