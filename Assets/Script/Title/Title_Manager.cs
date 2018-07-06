using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Manager : MonoBehaviour
{
    public int MUSICNUMBER;
    public Text TITLE;
    public Text LEVEL;
    public GameObject MS;
    string title;
    public int level;
    private void Start()
    {
        //MS.GetComponent<>
        switch (MUSICNUMBER)
        {
            case 0:
                title = "脳漿炸裂ガール";
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
                
        }
        TITLE.text = title.ToString();
    }

    private void Update()
    {
        //仮置き 
        level = Base.MusicLevel * 10;
        LEVEL.text = level.ToString();
    }



}
