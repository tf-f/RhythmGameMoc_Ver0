using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Select_home : MonoBehaviour {
    public int HOMEselect = 0;
    public int Setcase = 0; // Static....


    // Use this for initialization
    void Start () {
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
            Application.Quit();
        }

        if (HOMEselect < 2)
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

        if (Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.M) && Input.GetKeyDown(KeyCode.Space))
        {
            Base.SetMode = true;
            SceneManager.LoadScene("GameResult_all");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (HOMEselect)
            {
                case 0:
                    Base.SetMode= false;
                    SceneManager.LoadScene("SelectMusic");
                    break;
                case 1:
                    SceneManager.LoadScene("Results_all");
                    break;
                case 2:
                    Application.Quit();
                    break;
                case 3:
                    SceneManager.LoadScene("SelectMusic");
                    break;
                default:
                    Debug.Log("Not selected");
                    break;
            }
        }
    }
}
