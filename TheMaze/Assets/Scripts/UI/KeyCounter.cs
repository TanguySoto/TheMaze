using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyCounter : MonoBehaviour {

	public GameObject player;
	private Player p;

	public Text keyCounter;

	// Use this for initialization
	void Start () {
		p = player.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		keyCounter.text = "x " + p.keys;	
	}
}
