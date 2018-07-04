﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_music : MonoBehaviour {

    const int TOTALMUSIC = 15;
    const int LEVEL = 5;

    private int count = 0;
    //public bool select_level = false; //false MusicSelect true MusicLevelSelect
    public bool enable_select = true;

    public GameObject Start_Button;
    public GameObject[] Levels_Button;
    //Debug
    public int level = 0;
    public int music = 0;

	void Start () {
        Button_True();
        Levels_Button[0].GetComponent<Image>().color = Color.yellow;
        Base.MusicLevel = 0;
        Base.MusicNumber = 0;
        //select_level = false;
        count = 0;
        enable_select = true;
	}

    // Update is called once per frame
    void Update()
    {
        //Debug
        music = Base.MusicNumber;
        level = Base.MusicLevel;

        //Escape3回の入力でホームへ強制移動
        if (count > 3)
        {
            SceneManager.LoadScene("Home");
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {

            count = 0;
            if (enable_select)
            {
                Start_Button.GetComponent<Image>().color = Color.yellow;
                enable_select = false;
            }
            else
            {
                Start_Game();                
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enable_select)
            {
                count++;
            }
            else
            {
                enable_select = true;
                Start_Button.GetComponent<Image>().color = Color.white;
            }
        }

        if (enable_select)
        {
            //曲選択
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (TOTALMUSIC > Base.MusicNumber)
                {
                    Base.MusicNumber++;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (0 < Base.MusicNumber)
                {
                    Base.MusicNumber--;
                }
            }
            //難易度選択
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (0 < Base.MusicLevel)
                {
                    Level_Change(--Base.MusicLevel);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Base.MusicLevel < LEVEL - 1)
                {
                    Level_Change(++Base.MusicLevel);
                }

            }
        }

    }

    public void Start_Game()
    {
        {
            Start_Button.SetActive(false);
            if (Base.SetMode)
            {
                SceneManager.LoadScene("CreateMode");
            }
            else
            {
                SceneManager.LoadScene("GameMain");
            }
        }
    }

    public void Select_Music(int x)
    {
        Base.MusicNumber = x;
    }

    
    public void Level_Change(int x)
    {
        Button_True();
        Levels_Button[x].GetComponent<Image>().color= Color.yellow;
        Base.MusicLevel = x;
    }

    public void Button_True()
    {
        for(int i= 0; i < 5; i++)
        {
            Levels_Button[i].GetComponent<Image>().color = Color.white;
        }
    }
    
    public bool Able()
    {
        return enable_select;
    }
}
