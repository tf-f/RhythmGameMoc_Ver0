using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject[] notes;
    //public float[] _timing;
    private float[] _timing;


	public int Onece = 1;


	public static int speeds = 10;
	public int speed =10;
	private int[] _lineNum;

	public static float zz = 0.0f;
    //CSV 曲名取得
    // いずれか削除
    public string filePass;

    private MenuManager2 _MenuManager;

    //Audio 楽曲名取得
	public string AudioName;

	//spaceKey対策
	public bool space = false;
	double space_ = 0;


    private int _notesCount = 0;

	//Play audio
    private AudioSource _audioSource;
	private AudioSource _OnlyMyRailgun;
	private AudioSource _Nousyou;
	private AudioSource _Senbon;
	private AudioSource _ElementalCreation;
	private AudioSource _Maware;
    private AudioSource _FutureGazer;
	private AudioSource _errorcode;
	private AudioSource _contrapasso;
	private AudioSource _echo;
	private AudioSource _daisuke;
	private AudioSource _paranoia;
	private AudioSource _syakunetsu;
	private AudioSource _hesitation;
	private AudioSource _asuno;
	private AudioSource _level5;


	//double attac
	public bool li0 = false;
	public bool li1 = false;
	public bool li2 = false;
	public bool li3 = false;
	public bool li4 = false;
	public bool li5 = false;
	public bool li6 = false;
	public bool li7 = false;




    private float _startTime = 0;

    public float timeOffset = -1;

    public bool _isPlaying = false; // フラグ
    

	//Not used
	//private bool _CountStart = false;
    

	public GameObject startButton;

	public int levels = 0;


    /*
    internal static void Instantiate(object badMissEffect, Vector3 position, Quaternion rotation)
    {
        throw new NotImplementedException();
    }
    */

    // !!! エフェクトを一時無効；
    //エフェクトの収納
   

    

    //Score計算用変数
    // 後で修正
    public static float _score = 0;

    public static float Judgment = 0;


    //リザルト表示用

	//public static Text Judgments;

	// Scoreテキスト用変数
	public Text scoreText;
	public Text MaxComboText;
    
	//コンボ数
	public Text comboText;
    public static int _combo = 0;
    public float _combo_mag = 0;
    public static int MaxCombo = 0;

    //カウント
    public static int Perfects =0;
    public static int Greats=0;
    public static int Goods=0;
    public static int Bads=0;
    public static int Misses=0;


    // StartButtonを押した際、CSVをロード
    public void Start()
    {
		timeOffset = -1;
		_startTime = 0;
		_notesCount = 0;
		// switch(){
		speed =10;
		speeds = 10;
		zz = 0.0f;
		//
		try{

		switch (MenuManager2.music_select){
		case 0:
			//test後削除
			//_audioSource = GameObject.Find("Only My Railgun short").GetComponent<AudioSource>();
			_Nousyou = GameObject.Find ("Nousyou").GetComponent<AudioSource> ();
			filePass = "CSV/Nousyou";
			break;
		case 1:
			_OnlyMyRailgun = GameObject.Find ("Only My Railgun").GetComponent<AudioSource> ();
			filePass = "CSV/OnlyMyRailgun";
			break;
		case 2:
			_Maware = GameObject.Find ("Maware").GetComponent<AudioSource> ();
			filePass = "CSV/Maware";
			break;
		case 3:
			_ElementalCreation = GameObject.Find ("Elemental Creation").GetComponent<AudioSource> ();
			filePass = "CSV/ElementalCreation";
				//filePass += MenuManager.Level_.ToString ();
			break;
		case 4:
			_Senbon = GameObject.Find ("Senbonzakura").GetComponent<AudioSource> ();
            filePass = "CSV/Senbonzakura";
			break;
        case 5:
            _FutureGazer = GameObject.Find("FutureGazer").GetComponent<AudioSource>();
            filePass = "CSV/FutureGazer";
            break;
			case 6:
				_daisuke = GameObject.Find ("Daisuke").GetComponent <AudioSource>();
				filePass = "CSV/Daisuke";
				break;
			case 7:
				_errorcode = GameObject.Find("ERROR CODE").GetComponent<AudioSource>();
				filePass = "CSV/ERRORCODE";
				break;
			case 8:
				_contrapasso = GameObject.Find("Contrapasso").GetComponent<AudioSource>();
				filePass = "CSV/Contrapasso";
				break;
			case 9:
				_paranoia = GameObject.Find("PARANOiA").GetComponent<AudioSource>();
				filePass = "CSV/PARANOiA";
				break;
			case 10:
				_echo = GameObject.Find("ECHO").GetComponent<AudioSource>();
				filePass = "CSV/ECHO";
				break;
			case 11:
				_level5 = GameObject.Find("LEVEL5").GetComponent<AudioSource>();
				filePass = "CSV/LEVEL5";
				break;
			case 12:
				_syakunetsu =GameObject.Find("syakunetsu").GetComponent<AudioSource>();
				filePass = "CSV/beach";
				break;
			case 13:
				_hesitation = GameObject.Find("Hesitation Snow").GetComponent<AudioSource>();
				filePass = "CSV/hesitation";
				break;
			case 14:
				_asuno = GameObject.Find("asunoyozora").GetComponent<AudioSource>();
				filePass = "CSV/asuno";
				break;
			default:
				break;

			}
		}catch{
			SceneManager.LoadScene ("Catch Null");
		}
		filePass += Selecter_selectLevel.Level_.ToString ();


       
		//_OnlyMyRailgun = GameObject.Find("Only My Railgun").GetComponent<AudioSource>();
		// _audioSource = GameObject.Find("Only My Railgun short").GetComponent<AudioSource>();
		// 1024 to 8192
		_timing = new float[8192];
        _lineNum = new int[8192];
        LoadCSV();
        //
        /*
         * if (Time.time - _startTime >= 0.1)
        {

            _CountStart = true;
        }

		*/


        // 初期化
        Perfects = 0; Greats = 0; Goods = 0; Bads = 0; Misses = 0;
		_score = 0;
		_combo = 0;
		_combo_mag = 0;
		MaxCombo = 0;
    }


    //結果の表示
    /*
     * public void Result()
    {
        string _resultText;
        _resultText = "Perfects :" + Perfects + "Greats :" + Greats + "Goods :" + Goods + "Bads :" + Bads + "Misses :" + Misses;
        resultText.text = _resultText.ToString();
        Instantiate(Results, transform.position, transform.rotation);



    }
    */

    // Scoreの加算処理
    // 修正＊＊
    void Update()
	{
		if (_isPlaying == true) {
			CheckNextNotes ();
			if (space == false) {
				space_ += Time.deltaTime;
				if (space_ > 0.1) {
					space = true;
				}
			}
		}

		//強制リザルト画面表示
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			SceneManager.LoadScene ("Result");
		}		

		if (Input.GetKeyDown (KeyCode.Q)) {
			SceneManager.LoadScene ("HOME");
		}
		if (Onece == 1) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Onece = 0;
				StartGame ();
			}
		}
		// 二重フラグの修正？
		/*else if (!_isPlaying) {
            {
                if (_CountStart)
                {
                    resultText.text = "Score:" + _Results.ToString();
                }
            }
        }
        */

		//MaxComboの上書き
		if (MaxCombo <= _combo) {
			MaxCombo = _combo;
		}

		comboText.text = "Combo: " + _combo.ToString ();
		scoreText.text = "Score: " + _score.ToString ();
		MaxComboText.text = "MaxCombo:" + MaxCombo.ToString ();

		//誤差調整設定
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			timeOffset -= 0.1f;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {	
			timeOffset += 0.1f;
		}

		// speed変更時、ノーツ作成時間の変更
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (speeds < 15) {
				speeds++;
				speed++;
				timeOffset -= 0.5f;
				zz -= 0.17f;
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (speeds > 1) {
				speeds--;
				speed--;
				timeOffset += 0.5f;
				zz += 0.17f;
			}
		}
		//ReStart;

		//quit
		if (Input.GetKey ("escape")) {
			
			Application.Quit ();
		}
	}





    // 曲の再生
    public void StartGame()
    {
		//
        startButton.SetActive(false);
        _startTime = Time.time;
        

		// _audioSource.Play();
		switch (MenuManager2.music_select){
		case 0:
			//_audioSource.Play ();
			//テスト後削除
			_Nousyou.Play ();
			break;
		case 1:
			_OnlyMyRailgun.Play();
			break;
		case 2:
			_Maware.Play();
			break;
		case 3:
			_ElementalCreation.Play();
			break;
		case 4:
			_Senbon.Play();
			break;
        case 5:
            _FutureGazer.Play();
            break;
		case 6:
			_daisuke.Play ();
			break;
		case 7:
			_errorcode.Play ();
			break;
		case 8:
			_contrapasso.Play ();
			break;
		case 9:
			_paranoia.Play ();
			break;
		case 10:
			_echo.Play ();
			break;
		case 11:
			_level5.Play ();
			break;
		case 12:
			_syakunetsu.Play ();
			break;
		case 13:
			_hesitation.Play ();
			break;
		case 14:
			_asuno.Play ();
			break;
		default:
			break;

		}

        _isPlaying = true;

	

	
        //_CountStart = true;
	
    }


    void CheckNextNotes()
    {
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0)
        {
            SpawnNotes(_lineNum[_notesCount]);
            _notesCount++;
        }
    }

    //Notesの作成
    void SpawnNotes(int num)
    {
		// 終了処理
	
		if (num == 8) {
			SceneManager.LoadScene ("Result");
           
		} else {

        Instantiate(notes[num],
            new Vector3(-11.0f + (2.0f * num), 10.0f, 0),
            Quaternion.identity);     //Vector修正
		}

    }

    //譜面データの読み取り
    //長押しの対応　配列要素の追加（後日）
	//
	void LoadCSV()
    {

		//

        int i = 0, j;


        TextAsset csv = Resources.Load(filePass) as TextAsset;
		try{
	        StringReader reader = new StringReader(csv.text);
			while (reader.Peek() > -1)
			{

				string line = reader.ReadLine();
				string[] values = line.Split(',');
				for (j = 0; j < values.Length; j++)
				{
					_timing[i] = float.Parse(values[0]);
					_lineNum[i] = int.Parse(values[1]);

				}
				i++;
			}
		}catch{
			SceneManager.LoadScene ("Catch Null");
		}

        
    }

    //消さない！
    float GetMusicTime()
    {
        return Time.time - _startTime;
    }


    //入力処理


    //タイミングの処理
    // 時間取得 _timing[]の修正
    public static void GoodTimingFunc(int num)

    {

        Debug.Log("Line:" + num + " good!");
    }



    public static void JudgementSS(int Judgements)
    {

        switch (Judgements) {
            case 1:
                Judgment = 300.0f;
                break;
            case 2:
                Judgment = 100.0f;
                break;
            case 3:
                Judgment = 50.0f;
                break;

            default:
                Judgment = 0;
                break;
		}
    }
}

