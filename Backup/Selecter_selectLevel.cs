using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Selecter_selectLevel : MonoBehaviour {

	private MenuManager2 _MenuManager;
    public static int Level_;
    public int SelectLevels = 1;
	public bool setup = false;
	// Use this for initialization
	void Start () {
		_MenuManager = GameObject.Find ("MenuManager2").GetComponent<MenuManager2> ();
	}

	public int Levels(){
		return SelectLevels;
	}
	
	// Update is called once per frame
	void Update () {
        Level_ = SelectLevels;
		if (_MenuManager.Level == 1) {
			_MenuManager.select = false;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			_MenuManager.select = true;
			_MenuManager.Level = 0;
			setup = false;
		}

		if (_MenuManager.Level == 1) {
			setup = true;
			if (SelectLevels < 3) {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					if (SelectLevels > 0) {
						SelectLevels--;
						Vector3 pos = transform.position;
						transform.position = new Vector3 (pos.x - 4.25f, pos.y, pos.z);
					}
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					if (SelectLevels < 2) {
						SelectLevels++;
						Vector3 pos = transform.position;
						transform.position = new Vector3 (pos.x + 4.25f, pos.y, pos.z);
					} else {
						SelectLevels++;
						Vector3 pos = transform.position;
						transform.position = new Vector3 (pos.x - 4.25f, pos.y - 1.75f, pos.z);
					}
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					if (SelectLevels == 0) {
						SelectLevels += 3;
						Vector3 pos = transform.position;
						transform.position = new Vector3 (pos.x + 4.25f, pos.y - 1.75f, pos.z);
					}
					if (SelectLevels == 1) {
						SelectLevels += 2;
						Vector3 pos = transform.position;
						transform.position = new Vector3 (pos.x, pos.y - 1.75f, pos.z);
					} else if (SelectLevels == 2) {
						if (Input.GetKeyDown (KeyCode.DownArrow)) {
							SelectLevels += 2;
							Vector3 pos = transform.position;
							transform.position = new Vector3 (pos.x, pos.y - 1.75f, pos.z);
						} 
					}
				}
			
			} else if (SelectLevels == 3) {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					SelectLevels--;
					Vector3 pos = transform.position;			
					transform.position = new Vector3 (pos.x + 4.25f, pos.y + 1.75f, pos.z);
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					SelectLevels++;
					Vector3 pos = transform.position;
					transform.position = new Vector3 (pos.x + 4.25f, pos.y, pos.z);
				}
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					SelectLevels -= 2;
					Vector3 pos = transform.position;
					transform.position = new Vector3 (pos.x, pos.y + 1.75f, pos.z);
				}
			}else {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					SelectLevels--;
					Vector3 pos = transform.position;
					transform.position = new Vector3 (pos.x - 4.25f, pos.y, pos.z);
				}
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					SelectLevels = SelectLevels - 2;
					Vector3 pos = transform.position;
					transform.position = new Vector3 (pos.x, pos.y + 1.75f, pos.z);
				}
			}
		}



	}
}
