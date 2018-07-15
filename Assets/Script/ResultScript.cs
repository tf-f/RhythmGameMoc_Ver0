using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour {

	
	public Text MaxCombo;
    public Text Score;
    public Text Perfect;
    public Text Great;
    public Text Good;
    public Text Bad;
    public Text Miss;
    public Text Music;
	public string fileName;

	// Use this for initialization
	void Start () {
        Music.text = "MusicName : " + Base.MusicNumber.ToString() + Base.MusicLevel.ToString();
		MaxCombo.text = "MaxCombo : " + GameManage.combo_max.ToString();
	    Perfect.text = "Perfect : " + GameManage.perfect_all.ToString();
	    Great.text = "Great : " + GameManage.great_all.ToString();
	    Good.text = "Good : " + GameManage.good_all.ToString();
	    Bad.text = "Bad : " + GameManage.bad_all.ToString();
	    Miss.text = "Miss : " + GameManage.miss_all.ToString();
        Score.text = "Total Score : " + GameManage.score.ToString();
		WriteResult();

	}

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home");
        }
	}

	//Json File swap
	private void WriteResult(){


	}

}
