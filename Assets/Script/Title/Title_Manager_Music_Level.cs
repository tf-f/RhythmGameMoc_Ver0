using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Title_Manager_Music_Level : MonoBehaviour {
    public GameObject gm;
    private int MUSICTITLE;
    // Use this for initialization
	void Start () {
        MUSICTITLE = gm.GetComponent<Title_Manager>().MUSICNUMBER;
        switch (MUSICTITLE)
        {
            case 0:
                this.gameObject.ToString();
                break;

            case 1:
                break;
            case 2:
                break;
            default:
                break;

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
