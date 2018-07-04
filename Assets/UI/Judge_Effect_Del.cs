using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_Effect_Del : MonoBehaviour {

	public int Judge_E;
	//Case
	/* 1 = Perfect
	 * 2 = Great
	 * 3 = Good
	 * 4 = Bad
	 * 5 = Miss
	*/

	double Times_;
	private Judge_script Judge;


	// Use this for initialization
	void Start () {
		Judge = GameObject.Find ("JudgEfects").GetComponent<Judge_script> ();
		Times_ = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		Times_ += Time.deltaTime;
		if (Times_ > 0.4) {
			switch (Judge_E) {
			case 1:
				Judge._ePerfect = false;
				break;
			case 2:
				Judge._eGreat = false;
				break;
			case 3:
				Judge._eGood = false;
				break;
			case 4:
				Judge._eBad = false;
				break;
			case 5:
				Judge._eMiss = false;
				break;
			default :
				break;
			}
		}
		if (Judge_E == 1) {
			if (Judge._ePerfect == false) {
				Destroy (this.gameObject);
			}
		}
		if (Judge_E == 2) {
			if (Judge._eGreat == false) {
				Destroy (this.gameObject);
			}
		}
		if (Judge_E == 3) {
			if (Judge._eGood == false) {
				Destroy (this.gameObject);
			}
		}
		if (Judge_E == 4) {
			if (Judge._eBad == false) {
				Destroy (this.gameObject);
			}
		}
		if (Judge_E == 5) {
			if (Judge._eMiss == false) {
				Destroy (this.gameObject);
			}
		}

		
	}
}
