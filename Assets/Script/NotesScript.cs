﻿using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;
using UnityEngine;

public class NotesScript : MonoBehaviour {
    public int LINE;
    //falseなら単発 trueなら長押し
    //const
    public int Mode;      //長押し、単発
    public int Line_num = 0; //lane
    
    // テスト後private !!!
    public float timer;
    public bool _active = false;
    // JudgeFlag
    public bool _Perfect = false;
    public bool _Great = false;
    public bool _Good = false;
    public bool _Bad = false;
  
    //public GameObject objects;
    public GameManage gm;
     
    private float DIF = 0.0f;
    private float SPEED = 1.0f;
    //double attack
    //public bool once = false;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManage>();
        _active = false;
        //生成時,初回のみ適応とする
        SPEED = gm.Speed;
        DIF = gm.SpDf(SPEED);
        timer = 0f;

        //double attack
        _Perfect = false;
        _Great = false;
        _Good = false;
        _Bad = false;

        //Debug.Log(Line_num + " " + LINE);
        Line_num = gm.Now_Notes(LINE);
        //Line_num = gm.Now_Notes(LINE);


    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        this.transform.position += Vector3.down * SPEED * Time.deltaTime * 5;
        
        //Lifeが0になった時の強制終了処理
        if(gm._active == false)// || this.transform.position.y <= -3.9f)
        {
            Deth();
        }


        //いるかこれ？
        if(true)
        {
            _active = true;
        }

        //判定の状態 スパゲッティ(これ以外やり方分からない)
        ///!!!要調整
        if ( timer >= 1.93f + DIF && timer < 1.975f + DIF)
        {
            _Perfect = true;
            _Great = false;
            _Good = false;
            _Bad = false;
        }
        if (( timer > 1.90f + DIF && timer < 1.93f + DIF) || (timer >= 1.975f + DIF && timer < 2.005f + DIF))
        {
            _Great = true;
            _Perfect = false;
            _Good = false;
            _Bad = false;
        }
        if (( timer > 1.87f + DIF && timer <= 1.90f + DIF) || (timer >= 2.005f + DIF && timer < 2.035f + DIF))
        {
            _Good = true;
            _Perfect = false;
            _Great = false;
            _Bad = false;
        }
        if (( timer >= 1.85f + DIF && timer <= 1.87f + DIF) || (timer >= 2.035f + DIF && timer <= 2.055f + DIF))
        {
            _Perfect = false;
            _Great = false;
            _Good = false;
            _Bad = true;
        }
        if ( timer > 2.055f + DIF)
        {
            _Perfect = false;
            _Great = false;
            _Good = false;
            _Bad = false;
            gm.MissE();
            Deth();
        }

        //detect key judge
        if( Line_num == gm._Now_Line_Num[LINE] && gm._active)
        {
            switch(LINE)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftArrow)
                        || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)
                        || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        Judgement();
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        Judgement();
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.V))
                    {
                        Judgement();
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.N))
                    {
                        Judgement();
                    }
                    break;
                case 4:
                    if (Input.GetKeyDown(KeyCode.M))
                    {
                        Judgement();
                    }
                    break;
                case 5:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        Judgement();
                    }
                    break;
                case 6:
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        Judgement();
                    }
                    break;
                case 7:
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        Judgement();
                    }
                    break;
                case 8:
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        Judgement();
                    }
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
            gm.PerfectE();
            Deth();
        }
        else if (_Great)
        {
            gm.GreatE();
            Deth();
        }
        else if (_Good)
        {
            gm.GoodE();
            Deth();
        }
        else if (_Bad)
        {
            gm.BadE();
            Deth();
        }
        else
        {
            gm.Life-=1;
        }
    }

    void Deth()
    {
        //Update Notes now Number
        gm._Now_Line_Num[LINE]++;
        Destroy(this.gameObject);
    }
}
