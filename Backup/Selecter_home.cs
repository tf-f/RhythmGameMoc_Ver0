using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Selecter_home : MonoBehaviour {


	public int sss = 0;

	/*void Start(){
		home = GameObject.Find ("MainSorce");
		sss = home.GetComponent<HOME> ();
	
	}
	*/

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(sss < 2){
				Vector3 pos = transform.position;
				transform.position = new Vector3 (pos.x, pos.y-2, pos.z);
				sss++;
			}

		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (sss > 0) {
				sss--;
				Vector3 pos = transform.position;
				transform.position = new Vector3 (pos.x, pos.y+2, pos.z);
			}
		}
	}
}
