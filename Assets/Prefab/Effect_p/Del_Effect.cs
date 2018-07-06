using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del_Effect : MonoBehaviour {
    private float timer;
    public int tp = 0;
    public GameManage gm;
    // Use this for initialization
	void Start () {
        timer = 0;
        gm = GameObject.Find("GameManager").GetComponent<GameManage>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 1.5f)
        {
            Destroy(this.gameObject);
        }
        switch (tp)
        {
            case 0:
                if (!gm._ePerfect)
                {
                    Destroy(this.gameObject);
                }
                break;
                case 1:
                if (!gm._eGreat)
                {
                    Destroy(this.gameObject);
                }
                break;
            case 2:
                if (!gm._eGood)
                {
                    Destroy(this.gameObject);
                }
                break;
            case 3:
                if (!gm._eBad)
                {
                    Destroy(this.gameObject);
                }
                break;
            case 4:
                if (!gm._eMiss)
                {
                    Destroy(this.gameObject);
                }
                break;
            default:
                break;
        }
	}
}
