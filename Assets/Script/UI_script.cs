using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_script : MonoBehaviour {

    public Text SCORE;
    public Text LIFE;
    public Text SPEED;
    public Text COMBO;
    public Text COMBO_MAX;
    public Text[] Sum_Jg;
    //public Text[] UI;

    private int score_;
    private int life_;
    
    public GameObject gm;

    // Use this for initialization
    void Start () {
        score_ = GameManage.score;
        life_ = GameManage.life;
        SPEED.text = gm.GetComponent<GameManage>().Speed.ToString();

        SCORE.text = score_.ToString();
        LIFE.text = life_.ToString();
        COMBO.text = gm.GetComponent<GameManage>().combo.ToString();
        COMBO_MAX.text = GameManage.combo_max.ToString();

	}
	
	// Update is called once per frame
	void Update () {
        if (gm.GetComponent<GameManage>().Speed - 1.0f == 0)
        {
            SPEED.text = "±0.0";
        }
        else
        {
            SPEED.text = "SPEED" + ( gm.GetComponent<GameManage>().Speed - 1.0f ).ToString();
        }

        COMBO.text = "Combo: " + gm.GetComponent<GameManage>().combo.ToString();
        COMBO_MAX.text = "MaxCombo: " + GameManage.combo_max.ToString();
        while (GameManage.score < score_)
        {
            score_+= 10;
            SCORE.text ="Score: " + score_.ToString();
        }

        while(GameManage.life != life_)
        {
            if (life_ > GameManage.life)
            {
                life_--;
                LIFE.text = life_.ToString()+" %";
            }
            else
            {
                life_++;
                LIFE.text = life_.ToString()+" %";
            }

        }
	}
}
