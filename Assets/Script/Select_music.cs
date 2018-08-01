using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_music : MonoBehaviour {

    const int TOTALMUSIC = 8;
    const int LEVEL = 5;

    private int count = 0;
    //public bool select_level = false; //false MusicSelect true MusicLevelSelect
    public bool enable_select = true;
    public bool setmode;
    public GameObject Start_Button;
    public GameObject[] Levels_Button;
    public GameObject[] Music_Button;
    //Debug
    public int level = 0;
    public int music = 0;

    public int music_sort_dif = 0;

	void Start () {
        Button_Level_True();
        Music_Button[Base.MusicNumber].GetComponent<Image>().color = Color.yellow;
        Levels_Button[Base.MusicLevel].GetComponent<Image>().color = Color.yellow;
        //Base.MusicLevel = 0;
        //Base.MusicNumber = 0;
        //select_level = false;
        count = 0;
        enable_select = true;
	}

    // Update is called once per frame
    void Update()
    {
        setmode = Base.SetMode;
        //Debug
        music = Base.MusicNumber;
        level = Base.MusicLevel;
        if(Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.U))
        {
            Base.SetMode = true;
        }
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
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (TOTALMUSIC > Base.MusicNumber)
                {
                    Music_Change(Base.MusicNumber + 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (0 < Base.MusicNumber)
                {
                    Music_Change(Base.MusicNumber - 1);
                }
            }
            //難易度選択
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (0 < Base.MusicLevel)
                {
                    Level_Change(Base.MusicLevel - 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Base.MusicLevel < LEVEL - 1)
                {
                    Level_Change(Base.MusicLevel + 1);
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
    
    public void Level_Change(int x)
    {
        Button_Level_True();
        Levels_Button[x].GetComponent<Image>().color= Color.yellow;
        Base.MusicLevel = x;
    }

    public void Music_Change(int x)
    {
        Button_Music_True();
        x += music_sort_dif;
        Music_Button[x].GetComponent<Image>().color = Color.yellow;
        Base.MusicNumber = x;
    }

    public void Button_Level_True()
    {
        for(int i= 0; i < Levels_Button.Length; i++)
        {
            Levels_Button[i].GetComponent<Image>().color = Color.white;
        }
    }
    
    public void Button_Music_True()
    {
        for(int i=0; i < Music_Button.Length; i++)
        {
            Music_Button[i].GetComponent<Image>().color = Color.white;
        }
    }
    
    public bool Able()
    {
        return enable_select;
    }
}
