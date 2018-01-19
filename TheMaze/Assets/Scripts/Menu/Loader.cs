using UnityEngine;
using System.Collections;

public class Loader: MonoBehaviour {

	public void LoadScene(string name)
	{ 
		Application.LoadLevel(name);
	}
}