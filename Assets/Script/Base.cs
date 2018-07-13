using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//管理スクリプト 絶対起動させること
public class Base : MonoBehaviour {
    //曲番号の管理
    public static int MusicNumber = 0;
    //難易度の管理
    public static int MusicLevel = 0;
    //
    public static int MMM;

    public static int[] scores;
    


    //譜面作成、モードの切り替え
    public static bool SetMode = false; //false PlayGame true MakeGame

    void Start()
    {
        SetMode = false;
        scores = new int[20];
    }
    void Update()
    {


    }
    string Names(int i){

        return "a";
    }




}
