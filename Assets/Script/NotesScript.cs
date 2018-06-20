using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;
using UnityEngine;

public class NotesScript : MonoBehaviour {
    public int LINE;
    //falseなら単発 trueなら長押し
    //const
    public int Mode;      //長押し、単発
    private int Line_num; //lane
    
    // テスト後private !!!
    public float timer;
    public bool _active = false;
    // JudgeFlag
    public bool _Perfect = false;
    public bool _Great = false;
    public bool _Good = false;
    public bool _Bad = false;
    /// !!!
    

    //public GameObject objects;
    public GameObject gm;

    //private GameObject _judge;
    /*
    private Judge_script _js;

    private TapEffects _taps;
    */
    private float DIF = 0.0f;
    private float SPEED = 1.0f;
    //double attack
    //public bool once = false;

    void Start()
    {
        _active = false;
        //生成時,初回のみ適応とする
        DIF = gm.GetComponent<GameManage>().Dif;
        SPEED = gm.GetComponent<GameManage>().Speed;
        timer = 0f;
        ////_taps = GameObject.Find("TapEffect").GetComponent<TapEffects>();
        //_judge = GameObject.Find ("JudgEfects").GetComponent<Judge_script> ();

        //_js = GameObject.Find("JudgEfects").GetComponent<Judge_script>();

        //double attack
        _Perfect = false;
        _Great = false;
        _Good = false;
        _Bad = false;

        Line_num = gm.GetComponent<GameManage>().Now_Notes(LINE);


    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        //Lifeが0になった時の強制終了処理
        if(gm.GetComponent<GameManage>().done == false || this.transform.position.y <= -3.9f)
        {

            Destroy(this.gameObject);
        }
        this.transform.position += Vector3.down * SPEED * Time.deltaTime;

        //いるかこれ？
        if(true)
        {
            _active = true;
        }

        //判定の状態 スパゲッティ(これ以外やり方分からない)
        if (timer >= 1.4f + DIF && timer < 1.5f + DIF)
        {
            _Perfect = true;
            _Great = false;
            _Good = false;
            _Bad = false;
        }

        if ((timer > 1.35f + DIF && timer < 1.4f + DIF) || (timer >= 1.5f + DIF && timer < 1.55f + DIF))
        {
            _Great = true;
            _Perfect = false;
            _Good = false;
            _Bad = false;
        }
        if ((timer > 1.325f + DIF && timer <= 1.35f + DIF) || (timer >= 1.55f + DIF && timer < 1.58f + DIF))
        {
            _Good = true;
            _Perfect = false;
            _Great = false;
            _Bad = false;
        }
        if ((timer <= 1.325f + DIF && timer >= 1.3f + DIF) || (timer >= 1.58f + DIF && timer <= 1.61f + DIF))
        {
            _Perfect = false;
            _Great = false;
            _Good = false;
            _Bad = true;
        }
        if (timer > 1.61f + DIF)
        {
            _Perfect = false;
            _Great = false;
            _Good = false;
            _Bad = false;
            gm.GetComponent<GameManage>().MissE();
            Deth();
        }

      

        //detect key judge
        if(Line_num == gm.GetComponent<GameManage>()._Now_Line_Num[LINE] && _active)
        {
            switch(LINE)
            {
                case 0:
                    
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    break;
                default:
                    break;
            }
        }
    }
        

    void Judgement()
    {
        //タップ音とかも追加
        if (_Perfect)
        {
            gm.GetComponent<GameManage>().PerfectE();
        }
        else if (_Great)
        {
            gm.GetComponent<GameManage>().GreatE();
        }
        else if (_Good)
        {
            gm.GetComponent<GameManage>().GoodE();
        }
        else if (_Bad)
        {
            gm.GetComponent<GameManage>().BadE();
        }
        else
        {
            //
        }
    }

    void Deth()
    {
        //Update Notes now Number
        gm.GetComponent<GameManage>()._Now_Line_Num[LINE]++;

        Destroy(this.gameObject);
    }
}
