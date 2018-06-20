using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HOME : MonoBehaviour {

	public int HOMEselect = 0; 
	public static int Setcase = 0; // Static....
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();
		
		if (HOMEselect < 2) {
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				HOMEselect++;
			}
		} 
		if (HOMEselect > 0) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				HOMEselect--;
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			switch (HOMEselect) {
			case 0:
				Setcase = 0;
				SceneManager.LoadScene ("SelectMusic2");
				break;
			case 1:
				Application.Quit ();
				break;
			case 2:
				Setcase = 1;
				SceneManager.LoadScene ("SelectMusic2");
				break;
			default:
				Destroy (this.gameObject);
				break;
			}
		}
	}
}
