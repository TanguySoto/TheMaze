using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

	public GameObject healthBar;
	public Text healthText;
	public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = (int)player.health+"%";
		healthBar.transform.localScale = new Vector3 (player.health/100.0f, 1, 1);
	}
}
