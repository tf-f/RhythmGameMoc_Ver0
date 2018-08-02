using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;
using System;

public class GameManage : MonoBehaviour
{
    const int PERFECT_N = 300;
    const int GREAT_N = 150;
    const int GOOD_N = 100;
    const int BAD_N = 30;

    //Debug Life制限なし
    public bool DB = false;

    private int totalnotes;

    public GameObject StartButton;
    public bool done = false;

    //効果Effect
    public GameObject Perfect;
    public GameObject Great;
    public GameObject Good;
    public GameObject Bad;
    public GameObject Miss;
    public GameObject GameOver;
    public GameObject Clear;
    public GameObject FullCombo;
    public GameObject te;

    //Effect Del
    public bool _ePerfect = false;
    public bool _eGreat = false;
    public bool _eGood = false;
    public bool _eBad = false;
    public bool _eMiss = false;

    private float speed = 1.0f;
    public static int score = 0;
    public static int life = 100;
    public static float percent = 0.0f;
    //private int time = 0;
    private float dif = 0.0f;

    //Scene継承
    public static int combo;
    public static int combo_max;
    public static int perfect_all = 0;
    public static int great_all = 0;
    public static int good_all = 0;
    public static int bad_all = 0;
    public static int miss_all = 0;
    public static bool _fullcombo;

    private float _startTime = 0;

    public int _notesCount = 0;
    public string filePass;
    public int[] _lineNum;
    private float[] _timing;
    public int[] _Line_Num;
    public int[] _Now_Line_Num;

    public GameObject[] notes;
    /* 0 Center 0
     * 1 Line 1
     * 2 Line 2
     * 3 Line 3
     * 4 Line 4
     * 5 Center left
     * 6 Center right
     * 7 Center up
     * 8 Center down
     *
     * if+10
     * LongNotes;
     *
     *
     */
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();

    public bool _active = false;
    public bool instanted_GameOver = false;
    public bool finish = false;
    // Use this for initialization
    void Start()
    {
        DB = false;
        _startTime = 0f;
        Debug.Log("start");
        audioSource = gameObject.AddComponent<AudioSource>();

        //Music_all = gameObject.GetComponents<AudioSource>();
        //ゲームの有効化
        done = true;
        //各値の初期化
        _fullcombo = false;
        totalnotes = 0;
        speed = 1.0f;
        score = 0;
        life = 40;
        percent = 0.0f;
        //time = 0;

        ////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
        dif = -2.1f;


        combo = 0;
        combo_max = 0;
        perfect_all = 0;
        great_all = 0;
        good_all = 0;
        bad_all = 0;
        miss_all = 0;
        // old 1024 → new 8192
        //くさい、メモリの無駄 ﾀﾋんでどうぞ
        _timing = new float[114514];
        _lineNum = new int[114514];

        //は？
        //生成されたノーツとジャッジ対象の参照用
        _Line_Num = new int[20];
        _Now_Line_Num = new int[20];
        for(int i = 0; i < 20; i++)
        {
            _Line_Num[i] = 0;
            _Now_Line_Num[i] = 1;
        }

        _active = false;
        instanted_GameOver = false;
        finish = false;

        filePass = filePass + Base.MusicNumber.ToString() + Base.MusicLevel.ToString();
        LoadCSV();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Result");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DB = true;
        }
        if (DB)
        {
            Life = 100;
        }


        if(!_active && !instanted_GameOver && finish)
        {
            End();
        }


        //各スコアなどのUI 更新
        if(combo_max< combo)
        {
            combo_max = combo;
        }

        if (life < 0)
        {
            life = 0;
            _active = false;
            End();

        }
        if(life > 100)
        {
            life = 100;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home");
        }
        if (_active)
        {
            //常時ノーツ生成
            CheckNextNotes();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.M))
            {
                StartGame();
            }
        }

        //その他調整など
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Speed = speed + 0.1f;// + 0.1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Speed = speed - 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Dif = dif + 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Dif = dif - 0.1f;
        }

        //強制終了
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _active = false;
            SceneManager.LoadScene("Home");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        try{
            if (_startTime != 0 && GetMusicTime() >= 1.5f)
            {
                audioSource.UnPause();
            }
        }
        catch
        {


        }


    }


    //ノーツの生成
    float GetMusicTime()
    {
        return Time.time - _startTime;
    }

    void CheckNextNotes()
    {
        while (_timing[_notesCount] + Dif <= GetMusicTime() && _timing[_notesCount] != 0)
        {
            _Line_Num[_lineNum[_notesCount]]++; //初期ノーツ生成時の管理番号の取得用
            SpawnNotes(_lineNum[_notesCount]);
            _notesCount++;
        }

    }

    void SpawnNotes(int num)
    {
        Debug.Log(num);
        // 終了処理

        /*
                 float pdif = 0.0f;
        float alpha = 0.0f;
        switch (num)
        {
            case 1:
                pdif = 0;
                break;
            case 2:
                pdif = 1.8f;
                break;
            case 3:
                pdif = 6.0f;
                break;
            case 4:
                pdif = 7.8f;
                break;
            default:
                pdif = 3.9f;
                if( num == 5)
                {
                    alpha = 0.8f;
                }else if (num == 7)
                {
                    alpha = -0.75f;
                }
                else
                {
                    alpha = 0f;
                }
                break;

        }

        */

        Instantiate(notes[num], notes[num].transform.position,notes[num].transform.rotation);     //Vector修正
        //,            new Vector3(-7.4f + pdif, 5.0f+alpha, -2.6f),
        //,//            new Vector3(0,0,0),

    }


    //プレイ開始 トリガ
    public void StartGame()
    {
        StartButton.SetActive(false);
        _startTime = Time.time;
        _active = true;
        try
        {
            // GetComponent<AudioSource>().clip = Music_all[Base.MusicNumber];
            // GetComponent<AudioSource>().Play();
            //Music_all[Base.MusicNumber].Play();
            switch (Base.MusicNumber)
            {
                case 0:
                    audioSource.volume = 0.05f;
                    break;
                default:
                    audioSource.volume = 0.50f;
                    break;
            }

            audioSource.PlayOneShot(audioClip[Base.MusicNumber]);
            //audioSource.Pause();
            //audioSource.PlayDelayed(2.0f);
        }
        catch {
            Debug.Log("Audio failed!");
            SceneManager.LoadScene("Error");
        }
    }

    //楽曲ファイル データ 一括読み取り
    void LoadCSV()
    {
        int i = 0, j;

        TextAsset csv = Resources.Load(filePass) as TextAsset;
        Debug.Log("CSV Loading" + filePass);
        try
        {
            StringReader reader = new StringReader(csv.text);
            while (reader.Peek() > -1)
            {

                string line = reader.ReadLine();
                string[] values = line.Split(',');
                for (j = 0; j < values.Length; j++)
                {
                    _timing[i] = float.Parse(values[0]);
                    _lineNum[i] = int.Parse(values[1]);
                    if(_timing[i] == 0f)
                    {
                        j--;
                        i--;
                    }
                }
                i++;
            }
            Debug.Log("CSV Load Loaded");
        }
        catch
        {
            Debug.Log("CSV Load failed");
            SceneManager.LoadScene("Error");
        }
        totalnotes = i;

    }

    //ノーツの二重処理防止
    public int Now_Notes(int line_num)
    {
        //後で調整???
        return _Line_Num[line_num];
    }

    //Speed調整プロパティ
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if (value >= 0.5f && value <= 4.0f)
            {
                speed = value;
            }
        }
    }

    //判定調整 プロパティ
    public float Dif
    {
        get
        {
            return dif;
        }
        set
        {
            if (value >= -3.0f && value <= 3.0f)
            {
                dif = value;
            }
        }
    }

    //Life 処理
    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            if (value + life >= 100)
            {
                life = 100;
            }
            else if (value + life <= 0)
            {
                life = 0;
                _active = false;
            }
            else
            {
                if (DB)
                {
                    life = 100;
                }
                else
                {
                    life = value;
                }
            }
        }
    }

    //フルコンボしているか？
    bool FullCombo_Check()
    {
        if (totalnotes == perfect_all+great_all)
        {
            return true;
        }
        return false;
    }

    //終了処理
    private void End()
    {

        finish = true;
        _active = false;
        if (life <= 0)
        {
             Instantiate(GameOver);
        }
        else
        {
            Instantiate(Clear);
            if(FullCombo_Check())
            {
                _fullcombo = true;
                Instantiate(FullCombo);

            }
        }

        //Wait for 2Second
        //Using UniRx
        Debug.Log("Finish! GameOver");
        Observable.Timer(TimeSpan.FromMilliseconds(2000))
              .Subscribe(_ => SceneManager.LoadScene("Result"));
    }

    //スコア加算 ！比率調整
    void ScoreUpdate(int x)
    {
        double mag = 1.0;
        for(int i=combo; i > 0; i -= 50)
        {
            mag += 0.25;
        }
        score += (int)((x * mag) /10) * 10;
    }


    //効果表示,加算用
    public void PerfectE()
    {
        _ePerfect = true;
        _eGreat = false;
        _eGood = false;
        _eBad = false;
        _eMiss = false;
        te.GetComponent<TapEffects>().Perfect_Tap_Play();
        perfect_all++;
        combo++;
        ScoreUpdate(PERFECT_N);
        Instantiate(Perfect);
        life += 2;
    }
    public void GreatE()
    {
        _eGreat = true;
        _ePerfect = false;
        _eGood = false;
        _eBad = false;
        _eMiss = false;
        te.GetComponent<TapEffects>().Great_Tap_Play();
        great_all++;
        combo++;
        ScoreUpdate(GREAT_N);
        Instantiate(Great);
        life += 1;
    }
    public void GoodE()
    {
        _eGood = true;
        _ePerfect = false;
        _eGreat = false;
        _eBad = false;
        _eMiss = false;
        te.GetComponent<TapEffects>().Great_Tap_Play();
        good_all++;
        combo = 0;
        ScoreUpdate(GOOD_N);
        Instantiate(Good);
    }
    public void BadE()
    {

        _eBad = true;
        _ePerfect = false;
        _eGreat = false;
        _eGood = false;
        _eMiss = false;
        te.GetComponent<TapEffects>().Bad_Tap_Play();
        bad_all++;
        combo = 0;
        ScoreUpdate(BAD_N);
        Instantiate(Bad);
        bad_all++;
        life -= 2;
    }
    public void MissE()
    {
        _eMiss = true;
        _ePerfect = false;
        _eGreat = false;
        _eGood = false;
        _eBad = false;
        te.GetComponent<TapEffects>().Bad_Tap_Play();
        miss_all++;
        combo = 0;
        Instantiate(Miss);
        miss_all++;
        life -= 5;
    }

    //Debug
    public void GoodTimingFunc(int num)
    {

        Debug.Log("Line:" + num + " good!");
    }


    //ノーツ速度に対するジャッジタイミングの調整
    ///
    /// !!!!!!!!!! 要調整  !!!!!!!!!!!!!!!!!!!!!!
    ///
    public float SpDf(float x)
    {
        return (1 - x)*0.8f;
    }
}
