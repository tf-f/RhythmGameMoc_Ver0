/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// スイッチ
	public bool select = true;

	public bool genre_ = true;
	public int genre = 0;
	public bool flag_ = false; //軽量化のため

	// 楽曲情報の受け渡し用
	public static int music_select = 0;
	
	//public int mm;

	public int Level = 0;
	public int Levels = 1;

	public GameObject CreatMode;
	public Text MusicText1;
	public Text MusicText2;
	public Text MusicText3;
	public Text MusicText4;
	public Text MusicText5;
	private Selecter_selectLevel _Selecter_selectLevel;
    public static string music_csv;

    //public GameManager Menu;
    // Use this for initialization
    void Start() {
		_Selecter_selectLevel = GameObject.Find ("Selecter_Level").GetComponent<Selecter_selectLevel> ();

	}

    
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (genre_ == true) {
				if (genre != 2) {
					genre++;
					flag_ = true;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (genre_ == true) {
				if (genre != 0) {
					genre--;
					flag_ = true;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			SceneManager.LoadScene ("HOME");
		}
		if(Input.GetKeyDown (KeyCode.J)){
			SceneManager.LoadScene("SelectMusic2");
		}
        //例外処理 
        //Future Gazer -Fripside
        if (Input.GetKeyDown(KeyCode.F))
        {
            music_select = 5;
        }
		//mm = music_select;
		if (Level == 1) {
			if (Levels < 3) {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					if (Levels > 0) {
						Levels--;
					}
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					if (Levels < 2) {
						Levels++;
					} else {
						Levels++;
					}
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					if (Levels == 0) {
						Levels += 3;
					}
					if (Levels == 1) {
						Levels += 2;
					}
					if (Levels == 2) {
						Levels += 2;
					}
				}
			} else if (Levels == 3) {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					Levels--;
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					Levels++;
				}
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					Levels = Levels - 2;
				}
			} else {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					Levels--;
				}
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					Levels = Levels - 2;
				}
			}
		} else {
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (music_select < 4)
					music_select++;
					//select++;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (music_select > 0)
					music_select--;
					//select++;
			}
		}

		if ((Input.GetKeyDown (KeyCode.Space))) {
            if (_Selecter_selectLevel.setup == true) {
				
				//シーン移動　csvファイルの記録
				if (HOME.Setcase == 1) {
					try{
						SceneManager.LoadScene ("NotesTimingMaker");
					}catch{
						SceneManager.LoadScene ("Catch Null");
					}
				} else {
					music_csv += Levels.ToString ();
					try{
						SceneManager.LoadScene ("GameScene");
					}catch{
						SceneManager.LoadScene ("Catch Null");
					}
				}

			}else{
			//SceneManager.LoadScene ("GameScene");	
				// いずれCSV参照に全て変更
				switch (music_select) {
				case 0:
					music_csv = "Nousyou.csv";
					break;
				case 1:
					music_csv = "OnlyMyRailgun.csv";	
					break;
				case 2:
					music_csv = "Maware_s.csv";
					break;
				case 3:
					music_csv = "ElementalCreation.csv";
					break;
				case 4:
					music_csv = "Senbonzakura.csv";
					break;
                case 5:
                    music_csv = "FutureGazer.csv";
                    break;
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				default:
					break;	
				}
				Level = 1;

			}
		}

		if (flag_ == true) {
			switch(genre){
			case 0:
				MusicText1.text = "A".ToString ();
				MusicText2.text = "B".ToString ();
				MusicText3.text = "C".ToString ();
				MusicText4.text = "D".ToString ();
				MusicText5.text = "E".ToString ();
				break;
			case 1:
			case 2:
				break;
			default:
				break;
			}
			flag_ = false;
		}

    //    SceneManager.LoadScene("Home");
	/*
    public string FilePass()
    {
        return music_csv; 

    }
    */

	/* 曲の追加
	void XX(){
		SceneManager.LoadScene("");
	}
	 */
