using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_SelectMusicMK : MonoBehaviour {
	// Use this for initialization

	void Start () {

		if (HOME.Setcase == 0) {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
