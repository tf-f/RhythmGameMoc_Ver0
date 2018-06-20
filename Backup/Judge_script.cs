using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_script : MonoBehaviour {


	public GameObject Perfect;
	public GameObject Great;
	public GameObject Good;
	public GameObject Bad;
	public GameObject Miss;

	public bool _ePerfect = false;
	public bool _eGreat = false;
	public bool _eGood = false ;
	public bool _eBad = false;
	public bool _eMiss = false;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PerfectE(){

		_ePerfect = true;
		//_ePerfect = false;
		_eGreat = false;
		_eGood = false;
		_eBad = false;
		_eMiss = false;
		Instantiate (Perfect);

	}

	public void GreatE(){
		_eGreat = true;
		_ePerfect = false;
		//_eGreat = false;
		_eGood = false;
		_eBad = false;
		_eMiss = false;
		Instantiate (Great);
	}
	public void GoodE(){
		_eGood = true;
		_ePerfect = false;
		_eGreat = false;
		//_eGood = false;
		_eBad = false;
		_eMiss = false;
		Instantiate (Good);
	}
	public void BadE(){

		_eBad = true;
		_ePerfect = false;
		_eGreat = false;
		_eGood = false;
		//_eBad = false;
		_eMiss = false;

		Instantiate (Bad);
	}
	public void MissE(){
		_eMiss = true;
		_ePerfect = false;
		_eGreat = false;
		_eGood = false;
		_eBad = false;
		//_eMiss = false;

		Instantiate (Miss);
	}
}
