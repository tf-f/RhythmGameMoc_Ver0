using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result_Script : MonoBehaviour {

	public Text Perfect;
	public Text Great;
	public Text Good;
	public Text Bad;
	public Text Miss;
	public Text MaxCombo;
	public Text Score;
	public Text MusicTitle;
	public Text MusicLevel;

	public string mt;
	public string lt;

	/*
	// public Text Rank;
	public GameObject SSS;
	public GameObject SS;
	public GameObject S;
	public GameObject AAA;
	public GameObject AA;
	public GameObject A;
	public GameObject BBB;
	public GameObject BB;
	public GameObject B;
	public GameObject C;
	*/


	// Use this for initialization
	void Start () {
		Perfect.text = GameManager.Perfects.ToString();
		Great.text = GameManager.Greats.ToString ();
		Good.text = GameManager.Goods.ToString ();
		Bad.text = GameManager.Bads.ToString ();
		Miss.text = GameManager.Misses.ToString ();
		MaxCombo.text = "MaxCombo :  " + GameManager.MaxCombo.ToString ();
		Score.text = GameManager._score.ToString ();

		switch (MenuManager2.music_select){
		case 0:
			mt = "脳漿炸裂ガール";
			break;
		case 1:
			mt = "Only My Railgun";
			break;
		case 2:
			mt = "回レ！雪月花";
			break;
		case 3:
			mt = "Elemental Creation";
			break;
		case 4:
			mt = "千本桜";
			break;
		default:
			break;

		}
		switch (Selecter_selectLevel.Level_) {
		case 0:
			lt = " Easy";
			break;
		case 1:
			lt = "  Normal";
			break;
		case 2:
			lt = "  Hard";
			break;
		case 3:
			lt = "  Expert";
			break;
		case 4:
			lt = "  Master";
			break;
		default:
			break;
		}

		MusicTitle.text = mt.ToString ();
		MusicLevel.text = lt.ToString ();




		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene ("HOME");
		}
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}
		
	}
}
