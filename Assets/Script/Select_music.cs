using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_music : MonoBehaviour {

    const int TOTALMUSIC = 15;
    const int LEVEL = 5;

    private int count = 0;
    bool select_level = false; //false MusicSelect true MusicLevelSelect

    //Debug
    public int level = 0;
    public int music = 0;

	void Start () {
        Base.MusicLevel = 0;
        Base.MusicNumber = 0;
        count = 0;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count = 0;
            if (select_level)
            {
                if (Base.SetMode)
                {
                    SceneManager.LoadScene("CreateMode");
                }
                else
                {
                    SceneManager.LoadScene("GameMain");
                }
            }
            else
            {
                select_level = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (select_level)
            {
                select_level = false;
            }
            else
            {
                count++;
            }
        }

        //曲選択
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (select_level)
            {
                if (5 > Base.MusicLevel)
                {
                    Base.MusicLevel++;
                }
            }
            else
            {
                if (TOTALMUSIC > Base.MusicNumber)
                {
                    Base.MusicNumber++;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (select_level)
            {
                if (0 < Base.MusicLevel)
                {
                    Base.MusicLevel--;
                }
            }
            else
            {
                if (0 < Base.MusicNumber)
                {
                    Base.MusicNumber--;
                }
            }
        }
    }


    void LevelChange(int x)
    {

    }

}
