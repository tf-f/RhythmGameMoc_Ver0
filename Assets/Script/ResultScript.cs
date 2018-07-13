using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour {

	public GameObject Combo;
	public GameObject MaxCombo;
  public GameObject Perfect;
  public GameObject Great;
  public GameObject Good;
  public GameObject Bad;
  public GameObject Miss;

	public string fileName;

	// Use this for initialization
	void Start () {

		Combo.text = GameManage.combo.ToString();
		MaxCombo.text = GameManage.combo_max.ToString();
	  Perfect.text = GameManage.perfect_all.ToString();
	  Great.text = GameManage.great_all.ToString();
	  Good.text = Gamemana.good_all.ToString();
	  Bad.text = Gamemanage.bad_all.ToString();
	  Miss.text = GameManage.miss_all.ToString();

		WriteResult();

	}

	// Update is called once per frame
	void Update () {

	}

	//Json File swap
	private void WriteResult(){


	}

}
