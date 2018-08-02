using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Select_home : MonoBehaviour {
    public int HOMEselect = 0;
    public int Setcase = 0; // Static....

    public GameObject[] Button;

    // Use this for initialization
    void Start() {
        Base.SetMode = false; //再帰復帰時の初期化
        HOMEselect = 0;
        Setcase = 0;
        Button_Reset_Color();

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
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.K))
            {
                HOMEselect++;
                Button_Reset_Color();
            }
        }
        if (HOMEselect > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.I))
            {
                HOMEselect--;
                Button_Reset_Color();
            }
        }




        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.M))
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

    private void Button_Reset_Color()
    {
        for (int i = 0; i < Button.Length; i++)
        {
            Button[i].GetComponent<Image>().color = Color.white;
        }
        Button[HOMEselect].GetComponent<Image>().color = Color.yellow;
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
        Button_Reset_Color();
        Button_Reset_ALL();
        SceneManager.LoadScene("SelectMusic");
    }

    public void Show_Result()
    {
        try
        {
            Button_Reset_Color();
            Button_Reset_ALL();
            SceneManager.LoadScene("Results_all");
        }
        catch
        {

        }
    } 

    public void GameEnd()
    {
        Button_Reset_Color();
        Button_Reset_ALL();
        Application.Quit();
    }
}
