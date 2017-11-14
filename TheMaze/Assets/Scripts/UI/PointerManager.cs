using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointerManager : MonoBehaviour {

	[Range(0,10)]
	public float maxInteractionDistance;

	public Text pointedName;
	public GameObject origin;
	public GameObject direction;

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

		if (Physics.Raycast (origin.transform.position, direction.transform.forward, out hit)) {
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
