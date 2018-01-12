using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public bool isLaunched;

	public float LIFE_TIME;
	protected float launchedTime = -1;

	public float initialSpeed;

	public bool hasDamaged;
	public float DAMAGE;
	public float RANGE_DAMAGE;

	protected GameObject pointer;
	protected GameObject arrows;

	// Use this for initialization
	void Start () {
		pointer = GameObject.Find ("Pointer");
		arrows = GameObject.Find ("Arrows");
	}
	
	// Update is called once per frame
	void Update () {
		if (launchedTime != -1 && Time.time - launchedTime >= LIFE_TIME) {
			Destroy (this.gameObject);
		}
	}

	public void OnCollisionEnter(Collision col){
		GameObject others = col.gameObject;

		if (others.GetComponent<SimpleAgent> () != null && !hasDamaged) {
			hitAgent (others);
		}
	}

	protected void hitAgent(GameObject others){
		SimpleAgent a = others.GetComponent<SimpleAgent> ();

		// Actual damage
		float damage = (DAMAGE+Random.Range(0,RANGE_DAMAGE));
		if (a.health > damage) {
			hasDamaged = true;

			a.health -= damage;

			// update health bar
			GameObject bar = a.transform.GetChild(4).gameObject;
			bar.transform.localScale = new Vector3(a.health*0.015f, bar.transform.localScale.y, bar.transform.localScale.z);

			a.transform.GetChild (0).gameObject.GetComponent<Renderer> ().material = a.redMat;
			a.state = SimpleAgent.STATES.FIGHTING;
		} else {
			a.onDie ();
		}
	}

	public void shoot(){
		Vector3 direction = pointer.GetComponent<PointerManager> ().hitPoint.point - this.transform.position;
		direction.Normalize();

		this.GetComponent<Rigidbody> ().velocity = direction * initialSpeed;
		this.GetComponent<Rigidbody> ().useGravity = true;
		this.GetComponent<Collider> ().enabled = true;
		isLaunched = true;
		this.transform.parent = arrows.transform;

		launchedTime = Time.time;
	}
}
