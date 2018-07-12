using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public GameObject gm;
	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManage>().instanted_GameOver = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
