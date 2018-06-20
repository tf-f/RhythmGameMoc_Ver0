using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecter_selectMusic : MonoBehaviour {

	private MenuManager2 _MenuManager;
	public int SelectMusics = 0;
	// Use this for initialization
	void Start () {
		
		_MenuManager = GameObject.Find ("MenuManager2").GetComponent<MenuManager2> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_MenuManager.Level == 0) {
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (SelectMusics < 4) {
					Vector3 pos = transform.position;
					transform.position = new Vector3 (pos.x, pos.y - 1.89f, pos.z);
					SelectMusics++;
				}

			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (SelectMusics > 0) {
					SelectMusics--;
					Vector3 pos = transform.position;
					transform.position = new Vector3 (pos.x, pos.y + 1.89f, pos.z);
				}
			}
		}

	}
}
