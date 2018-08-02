using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;

public class Selecter_Select_Direction : MonoBehaviour {
    public GameObject Select;
    private float x, y, z;
    // Use this for initialization
	void Start () {

        x = 329;
        y = 292;
        z = 48.4f;
        this.transform.position = new Vector3(x,y,z);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
        {
            y = 51f;
            Observable.Return(Unit.Default)
    .Delay(TimeSpan.FromMilliseconds(100))
    .Subscribe(_ =>
            this.transform.position = new Vector3( 47 + 169 * Base.MusicLevel, y , z));
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.M))
        {
            Observable.Return(Unit.Default)
    .Delay(TimeSpan.FromMilliseconds(100))
    .Subscribe(_ => z = 50);
            if (Select.GetComponent<Select_music>().enable_select)
            {
                x = 724f;
                y = 168f;
                this.transform.position = new Vector3(x, y, z);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            x = 329;
            y = 292;
            this.transform.position = new Vector3(x, y, z);
        }
	}
}
