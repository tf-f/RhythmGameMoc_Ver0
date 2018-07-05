using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Line : MonoBehaviour {
    public int line;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        switch (line)
        {
            case 0:
                if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftArrow)
                    || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow)
                    || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    Destroy(this.gameObject);
                }
                break;
            case 1:
                if (Input.GetKeyUp(KeyCode.C))
                {
                    Destroy(this.gameObject);
                }
                break;
            case 2:
                if (Input.GetKeyUp(KeyCode.V))
                {
                    Destroy(this.gameObject);

                }
                break;
            case 3:
                if (Input.GetKeyUp(KeyCode.N))
                {
                    Destroy(this.gameObject);
                }
                break;
            case 4:
                if (Input.GetKeyUp(KeyCode.M))
                {
                    Destroy(this.gameObject);

                }
                break;
            default:
                break;
        }
    
    }
}
