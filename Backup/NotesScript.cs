using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UniRx;

public class NotesScript : MonoBehaviour
{
	
    public int lineNum;
	public double judgeTime;
	public bool _active = false;
    // JudgeFlag
    public bool _Perfect = false;
    public bool _Great = false;
    public bool _Good = false;
    public bool _Bad = false;
	public bool _Miss = false;

	public GameObject objects;


	private GameObject _judge;
	private Judge_script _js;

	private GameManager _game;
	private TapEffects _taps;
	public float error = 0;

	//double attack
	public bool once= false;
    
	void Start(){
		error = GameManager.zz;
		_taps = GameObject.Find ("TapEffect").GetComponent<TapEffects> ();
		//_judge = GameObject.Find ("JudgEfects").GetComponent<Judge_script> ();
		_game = GameObject.Find ("GameManajer").GetComponent<GameManager> ();
		_js = GameObject.Find ("JudgEfects").GetComponent<Judge_script> ();

		//double attack

	}

    void Update()
	{
		
		this.transform.position += Vector3.down * GameManager.speeds * Time.deltaTime;
		judgeTime += Time.deltaTime;
		// 座標から判定をする。
		//何もしない。
		//Perfect
		//終了処理ß
		if (this.transform.position.x >= 6) {
			SceneManager.LoadScene ("Result");
		}
			

		//Judge処理のフラグ
		//一回のみ有効
		if (judgeTime > 1.3f + error) {
			if (once == false) {
				switch (lineNum) {
				case 0:
					if (_game.li0 == false) {	
						_active = true;
						_game.li0 = true;
						once = true;
					}
					break;
				case 1:
					if (_game.li1 == false) {
						_active = true;
						_game.li1 = true;
						once = true;

					}
					break;

				case 2:
					if (_game.li2 == false) {
						_active = true;
						_game.li2 = true;
						once = true;

					}
					break;

				case 3:
					if (_game.li3 == false) {
						_active = true;
						_game.li3 = true;
						once = true;

					}
					break;
				
				case 4:
					if (_game.li4 == false) {
						_active = true;
						_game.li4 = true;
						once = true;

					}
					break;
				case 5:
					if (_game.li5 == false) {
						_active = true;
						_game.li5 = true;
						once = true;

					}
					break;
				case 6:
					if (_game.li6 == false) {
						_active = true;
						_game.li6 = true;
						once = true;

					}
					break;
				case 7:
					if (_game.li7 == false) {
						_active = true;
						_game.li7 = true;
						once = true;

					}
					break;
				}
			}
		} 
		//if(transform.position

		if (_active) {
			if (judgeTime >= 1.3f + error && judgeTime <= 1.61f + error) {
				switch (lineNum) {
				case 0:
					_taps.l00 = false;
					break;
				case 1:
					_taps.l01 = false;
					break;
				case 2:
					_taps.l02 = false;
					break;
				case 3:
					_taps.l03 = false;
					break;
				case 4:
					_taps.l04 = false;
					break;
				case 5:
					_taps.l05 = false;
					break;
				case 6:
					_taps.l06 = false;
					break;
				case 7:
					_taps.l07 = false;
					break;

				default:
					break;
				}
			}
			//以後あたり判定条件
			if (judgeTime >= 1.4f + error && judgeTime < 1.5f + error) {
				_Perfect = true;
				_Great = false;
				_Good = false;
				_Bad = false;
			}

			if ((judgeTime > 1.35f + error && judgeTime < 1.4f + error) || (judgeTime >= 1.5f + error && judgeTime < 1.55f + error)) {
				_Great = true;
				_Perfect = false;
				_Good = false;
				_Bad = false;
			}
			if ((judgeTime > 1.325f + error && judgeTime <= 1.35f + error) || (judgeTime >= 1.55f + error && judgeTime < 1.58f + error)) {
				_Good = true;
				_Perfect = false;
				_Great = false;
				_Bad = false;
			}
			if ((judgeTime <= 1.325f + error && judgeTime >= 1.3f + error) || (judgeTime >= 1.58f + error && judgeTime <= 1.61f + error)) {
				_Perfect = false;
				_Great = false;
				_Good = false;
				_Bad = true;
			}
			if (judgeTime > 1.61f + error) {
				_Perfect = false;
				_Great = false;
				_Good = false;
				_Bad = false;
				_Miss = true;
				GameManager.Misses++;
				GameManager._combo = 0;
				// GameManager.Judgments.text = "Miss".ToString ();
				Debug.Log ("false");

				switch (lineNum) {
				case 0:
					_taps.l00 = true;
					break;
				case 1:
					_taps.l01 = true;
					break;
				case 2:
					_taps.l02 = true;
					break;
				case 3:
					_taps.l03 = true;
					break;
				case 4:
					_taps.l04 = true;
					break;
				case 5:
					_taps.l05 = true;
					break;
				case 6:
					_taps.l06 = true;
					break;
				case 7:
					_taps.l07 = true;
					break;

				default:
					break;

				}
				flag ();
				Destroy (this.gameObject);
              


				//GameManager.Judgment.text = "";
				//GameManager.Judgment.text = "Miss".ToString();
			}

		}


		if (_active == true) {                 //エフェクト未実装
			if (_Perfect) {
				switch (lineNum) {
				case 0:
					if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift)) {
						Perfect ();
					} 
					break;
				case 1:
					if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.Comma) || Input.GetKeyDown (KeyCode.Alpha2)) {
						Perfect ();
					}
					break;

				case 3:
					if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Period) || Input.GetKeyDown (KeyCode.Alpha4)) {
						Perfect ();
					} 
					break;
				case 5:
					if (Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.Slash) || Input.GetKeyDown (KeyCode.Alpha6)) {
						Perfect ();
					}
					break;
				case 7:
					if (Input.GetKeyDown (KeyCode.V) || Input.GetKeyDown (KeyCode.Backslash) || Input.GetKeyDown (KeyCode.Underscore) || Input.GetKeyDown (KeyCode.Alpha8)) {
						Perfect ();
					}
					break;
				case 2:
					if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.L) || Input.GetKeyDown (KeyCode.Alpha3)) {
						Perfect ();
					}
					break;
				case 4:
					if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.Semicolon) || Input.GetKeyDown (KeyCode.Alpha5)) {
						Perfect ();
					}
					break;
				case 6:
					if (Input.GetKeyDown (KeyCode.Colon) || Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.Alpha7)) {
						Perfect ();
					}
					break;
				default:
					break;
				}

			}
			if (_Great == true) {
				switch (lineNum) {
				case 0:
					if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift)) {
						Great();
					} 
					break;
				case 1:
					if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.Comma) || Input.GetKeyDown (KeyCode.Alpha2)) {
						Great ();
					}
					break;

				case 3:
					if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Period) || Input.GetKeyDown (KeyCode.Alpha4)) {
						Great ();
					} 
					break;
				case 5:
					if (Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.Slash) || Input.GetKeyDown (KeyCode.Alpha6)) {
						Great ();
					}
					break;
				case 7:
					if (Input.GetKeyDown (KeyCode.V) || Input.GetKeyDown (KeyCode.Backslash) || Input.GetKeyDown (KeyCode.Underscore) || Input.GetKeyDown (KeyCode.Alpha8)) {
						Great ();
					}
					break;
				case 2:
					if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.L) || Input.GetKeyDown (KeyCode.Alpha3)) {
						Great ();
					}
					break;
				case 4:
					if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.Semicolon) || Input.GetKeyDown (KeyCode.Alpha5)) {
						Great ();
					}
					break;
				case 6:
					if (Input.GetKeyDown (KeyCode.Colon) || Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.Alpha7)) {
						Great ();
					}
					break;
				default:
					break;
				}

			}
			if (_Good == true) {
				switch (lineNum) {
				case 0:
					if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift)) {
						Good ();
					} 
					break;
				case 1:
					if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.Comma) || Input.GetKeyDown (KeyCode.Alpha2)) {
						Good ();
					}
					break;

				case 3:
					if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Period) || Input.GetKeyDown (KeyCode.Alpha4)) {
						Good ();
					} 
					break;
				case 5:
					if (Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.Slash) || Input.GetKeyDown (KeyCode.Alpha6)) {
						Good ();
					}
					break;
				case 7:
					if (Input.GetKeyDown (KeyCode.V) || Input.GetKeyDown (KeyCode.Backslash) || Input.GetKeyDown (KeyCode.Underscore) || Input.GetKeyDown (KeyCode.Alpha8)) {
						Good ();
					}
					break;
				case 2:
					if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.L) || Input.GetKeyDown (KeyCode.Alpha3)) {
						Good ();
					}
					break;
				case 4:
					if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.Semicolon) || Input.GetKeyDown (KeyCode.Alpha5)) {
						Good ();
					}
					break;
				case 6:
					if (Input.GetKeyDown (KeyCode.Colon) || Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.Alpha7)) {
						Good ();
					}
					break;
				default:
					break;
				}

			}
			if (_Bad == true) {
				switch (lineNum) {
				case 0:
					if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift)) {
						Bad ();
					} 
					break;
				case 1:
					if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.Comma) || Input.GetKeyDown (KeyCode.Alpha2)) {
						Bad ();
					}
					break;

				case 3:
					if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Period) || Input.GetKeyDown (KeyCode.Alpha4)) {
						Bad ();
					} 
					break;
				case 5:
					if (Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.Slash) || Input.GetKeyDown (KeyCode.Alpha6)) {
						Bad ();
					}
					break;
				case 7:
					if (Input.GetKeyDown (KeyCode.V) || Input.GetKeyDown (KeyCode.Backslash) || Input.GetKeyDown (KeyCode.Underscore) || Input.GetKeyDown (KeyCode.Alpha8)) {
						Bad ();
					}
					break;
				case 2:
					if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.L) || Input.GetKeyDown (KeyCode.Alpha3)) {
						Bad ();
					}
					break;
				case 4:
					if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.Semicolon) || Input.GetKeyDown (KeyCode.Alpha5)) {
						Bad ();
					}
					break;
				case 6:
					if (Input.GetKeyDown (KeyCode.Colon) || Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.Alpha7)) {
						Bad ();
					}
					break;
				default:
					break;
				}

			}
		}
	}

	void Perfect(){
		int Judgements = 1;
		GameManager.JudgementSS (Judgements);
		GameManager.GoodTimingFunc (lineNum);
		GameManager.Perfects++;
		GameManager._score += 300.0f;
		GameManager._combo++;
		// GameManager.Judgments.text = "Perfect";
		_taps.sound_p.Play();
		flag();

		Destroy (this.gameObject);
	}

	void Great(){
		int Judgements = 2;
		GameManager.JudgementSS (Judgements);
		GameManager.GoodTimingFunc (lineNum);
		GameManager.Greats++;
		GameManager._score += 150.0f;
		GameManager._combo++;
		// GameManager.Judgments.text = "Great";
		_taps.sound_g.Play();
		flag(); Destroy (this.gameObject);
	}

	void Good(){
		int Judgements = 3;
		GameManager.JudgementSS (Judgements);
		GameManager.GoodTimingFunc (lineNum);
		GameManager.Goods++;
		GameManager._score += 60.0f;
		GameManager._combo++;
		// GameManager.Judgments.text = "Good";
		_taps.sound_g.Play();

		flag(); Destroy (this.gameObject);
	}
	void Bad(){
		int Judgements = 4;
		GameManager.JudgementSS (Judgements);
		GameManager.GoodTimingFunc (lineNum);
		GameManager.Bads++;
		GameManager._score += 10.0f;
		//GameManager._combo++;
		// GameManager.Judgments.text = "Bad";
		flag(); Destroy (this.gameObject);
	}


	void flag(){

		switch (lineNum) {
		case 0:
			Observable.Timer(TimeSpan.FromMilliseconds(10))
				.Subscribe(_ =>_game.li0 = false);
			break;
		case 1:
			Observable.Timer(TimeSpan.FromMilliseconds(10))
				.Subscribe(_ =>_game.li1 = false);
				break;
		case 2:
			Observable.Timer(TimeSpan.FromMilliseconds(10))
				.Subscribe(_ =>_game.li2 = false);
			
			break;
		case 3:
			Observable.Timer(TimeSpan.FromMilliseconds(10))
				.Subscribe(_ =>_game.li3 = false);
			
			break;
		case 4:
			Observable.Timer(TimeSpan.FromMilliseconds(10))
				.Subscribe(_ =>_game.li4 = false);
			
			break;
		case 5:
			Observable.Timer(TimeSpan.FromMilliseconds(10))
				.Subscribe(_ =>_game.li5 = false);
			
			break;
		case 6:
			Observable.Timer(TimeSpan.FromMilliseconds(10))
				.Subscribe(_ =>_game.li6 = false);
			
			break;
		case 7:
			Observable.Timer(TimeSpan.FromMilliseconds(10))
				.Subscribe(_ =>_game.li7 = false);
			
			break;
		default:
			break;
		}

		if (_Perfect == true) {
			_js.PerfectE();
		}
		if (_Great == true) {
			_js.GreatE();
		}
		if (_Good == true) {
			_js.GoodE ();
		}
		if (_Bad == true) {
			GameManager._combo = 0;
			_js.BadE ();
		}
		if(_Miss == true){
			_js.MissE ();
		}
		
	}
}


