using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Select_home : MonoBehaviour {
    public int HOMEselect = 0;
    public int Setcase = 0; // Static....

    public GameObject[] Button;

    // Use this for initialization
    void Start() {
        Base.SetMode = false; //再帰復帰時の初期化
        HOMEselect = 0;
        Setcase = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {         //makeUI;
            //終了確認画面 UIの生成
            GameEnd();
        }

        if (HOMEselect < 3)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                HOMEselect++;
            }
        }
        if (HOMEselect > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                HOMEselect--;
            }
        }




        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            switch (HOMEselect)
            {
                case 0:
                    Base.SetMode = false;
                    Select_Music();
                    break;
                case 1:
                    Base.SetMode = true;
                    Select_Music();
                    break;
                case 2: 
                    Show_Result();
                    break;
                case 3:
                    GameEnd();
                    break;
                default:
                    Debug.Log("Not selected");
                    break;
            }
        }
    }

    private void Button_Reset_ALL()
    {
        for (int i = 0; i < 4; i++)
        {
            Button[i].SetActive(false);
        }
    }

    public void SetMode()
    {
        Button_Reset_ALL();
        Base.SetMode = true;
        Select_Music();
    }

    public void Select_Music()
    {
        Button_Reset_ALL();
        SceneManager.LoadScene("SelectMusic");
    }

    public void Show_Result()
    {
        Button_Reset_ALL();
        SceneManager.LoadScene("Results_all");
    }

    public void GameEnd()
    {
        Button_Reset_ALL();
        Application.Quit();
    }
}
