using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecter_home : MonoBehaviour {
    private int selecter=0;
    private float x, y, z;
    // Use this for initialization
    void Start()
    {
        this.transform.position = new Vector3(315, 400, 1);
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        if (selecter < 3)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selecter++;
                y -= 80;
                this.transform.position = new Vector3(x,y,z);
            }
        }
        if (selecter > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selecter--;
                y += 80;
                this.transform.position = new Vector3(x, y, z);
            }
        }
    }
}
