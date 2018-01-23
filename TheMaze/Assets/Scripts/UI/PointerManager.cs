using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointerManager : MonoBehaviour {

	[Range(0,20)]
	public float maxInteractionDistance;

	public Camera fpsCamera;

	public Text pointedName;
	public GameObject targetedObject;
	public RaycastHit hitPoint;

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
			hitPoint = hit;
			if (distance < maxInteractionDistance) {
				pointedName.text = hit.collider.gameObject.name + "";
				targetedObject = hit.collider.gameObject;

				if (targetedObject.GetComponent<Activable> () != null) {
					pointedName.color = Color.white;
				} else {
					pointedName.color = Color.white;
				}
			} else {
				pointedName.text = "-";
				pointedName.color = new Color (1, 0.8f, 0.3f);
				targetedObject = null;
			}
		}
		else {
			pointedName.text = "-";
			pointedName.color = new Color (1, 0.8f, 0.3f);
			targetedObject = null;
		}
	}
}
