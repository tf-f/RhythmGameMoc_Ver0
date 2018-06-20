using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*曲の管理番号について
 * 1.only my railgun
 * 2.回れ雪月花
 * 3.Elemental Creation
 * 4.脳漿炸裂ガール
 * 5.千本桜
 * 6.Future Gazer
 * 7.Daisuke
 * 8.ERROR CODE
 * 9.Contrapasso paradiso
 * 10.PARANOiA(kskst mix)
 * 11.ECHO
 * 12.LVEL5 -judgelight-
 * 13.灼熱
 * 14.Hesitation Snow
 * 15.アスノヨゾラ哨戒班
 * 
*/



public class MenuManager2 : MonoBehaviour {

	// スイッチ
	public bool select = true;

	public bool genre_ = true;
	public int genre = 0;
	public bool flag_ = false; //軽量化のため


	// 楽曲情報の受け渡し用
	public static int music_select = 0;
	public int music_selectss;
	//public int mm;

	public int Level = 0;
	public int Levels = 1;

	public GameObject CreatMode;
	private Selecter_selectLevel _Selecter_selectLevel;
	public static string music_csv;
	public Text MusicText1;
	public Text MusicText2;
	public Text MusicText3;
	public Text MusicText4;
	public Text MusicText5;

	//public GameManager Menu;
	// Use this for initialization
	void Start() {
		flag_ = true;
		music_select = 0;
		_Selecter_selectLevel = GameObject.Find ("Selecter_Level").GetComponent<Selecter_selectLevel> ();

	}



	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (genre_ == true && Level == 0) {
				if (genre != 2) {
					genre++;
					music_select += 5;
					flag_ = true;
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (genre_ == true && Level == 0) {
				if (genre != 0) {
					genre--;
					music_select -= 5;
					flag_ = true;
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			SceneManager.LoadScene ("HOME");
		}
		if(Input.GetKeyDown (KeyCode.F)){
			SceneManager.LoadScene("SelectMusic");
		}
		//例外処理 
		//Future Gazer -Fripside
		
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
				if (music_select%5 < 4)
					music_select++;
				//select++;
			}
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (music_select%5 > 0)
					music_select--;
				//select++;
			}
		}

		if ((Input.GetKeyDown (KeyCode.Space))) {
			if (_Selecter_selectLevel.setup == true) {

				//シーン移動　csvファイルの記録
				if (HOME.Setcase == 1) {
					SceneManager.LoadScene ("NotesTimingMaker");
				} else {
					music_csv += Levels.ToString ();
					SceneManager.LoadScene ("GameScene");
				}

			} else {
				//SceneManager.LoadScene ("GameScene");	
				// いずれCSV参照に全て変更
				switch (music_select) {
				case 0:
					music_csv = "Nousyou";
					break;
				case 1:
					music_csv = "OnlyMyRailgun";	
					break;
				case 2:
					music_csv = "Maware";
					break;
				case 3:
					music_csv = "ElementalCreation";
					break;
				case 4:
					music_csv = "Senbonzakura";
					break;
				case 5:
					music_csv = "FutureGazer";
					break;
				case 6:
					music_csv = "Daisuke";
					break;
				case 7:
					music_csv = "ERRORCODE";
					break;
				case 8:
					music_csv = "Contrapasso";
					break;
				case 9:
					music_csv = "PARANOiA";
					break;
				case 10:
					music_csv = "ECHO";
					break;
				case 11:
					music_csv = "LEVEL5";
					break;
				case 12:
					music_csv = "beach";
					break;
				case 13:
					music_csv = "hesitation";
					break;
				case 14:
					music_csv = "asuno";
					break;
				default:
					break;	
				}
				Level = 1;
			}

		}
		if (flag_ == true) {
			switch(genre){
			case 0:
				MusicText1.text = "脳漿炸裂ガール".ToString ();
				MusicText2.text = "Only My Railgun".ToString ();
				MusicText3.text = "回レ!雪月花".ToString ();
				MusicText4.text = "Elemental Creation".ToString ();
				MusicText5.text = "千本桜".ToString ();
				break;
			case 1:
				MusicText1.text = "Future Gazer".ToString ();
				MusicText2.text = "Daisuke".ToString ();
				MusicText3.text = "ERROR CODE".ToString ();
				MusicText4.text = "Contrapasso paradiso".ToString ();
				MusicText5.text = "PARANOiA(kskst mix)".ToString ();
				break;
			case 2:MusicText1.text = "ECHO".ToString ();
				MusicText2.text = "LEVEL5 -judgelight-".ToString ();
				MusicText3.text = "灼熱".ToString ();
				MusicText4.text = "Hesitation Snow".ToString ();
				MusicText5.text = "アスノヨゾラ哨戒班".ToString ();
				break;
			default:
				break;
			}
		
		}
		music_selectss = music_select;

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

}


