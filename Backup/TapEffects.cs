using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffects : MonoBehaviour {

	public GameManager __space;

	public GameObject LINE0;
	public GameObject LINE1;
	public GameObject LINE2;
	public GameObject LINE3;
	public GameObject LINE4;
	public GameObject LINE5;
	public GameObject LINE6;
	public GameObject LINE7;



	//効果音の収納
	private AudioSource tap;
	//public GameObject Long;

	public AudioSource sound_p;
	public AudioSource sound_g;
	public AudioSource sound_m;



	//public AudioSource tap (1);

	//LINE用
	public bool l0 = true;
	public bool l1 = true;
	public bool l2 = true;
	public bool l3 = true;
	public bool l4 = true;
	public bool l5 = true;
	public bool l6 = true;
	public bool l7 = true;


	//効果音用
	public bool l00 = true;
	public bool l01 = true;
	public bool l02 = true;
	public bool l03 = true;
	public bool l04 = true;
	public bool l05 = true;
	public bool l06 = true;
	public bool l07 = true;

	// Use this for initialization
	void Start () {
		__space = GameObject.Find ("GameManajer").GetComponent<GameManager>();
		tap = GameObject.Find ("LINETap").GetComponent<AudioSource> ();
		sound_g = GameObject.Find ("GreatGoodTap").GetComponent<AudioSource> ();
		//sound_m = GameObject.Find ("").GetComponent<AudioSource> ();
		sound_p = GameObject.Find("PerfectTap").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{	
		// Count DelTime
		//delTime += Time.deltaTime;
		// 消滅処理

		if (__space.space == true) {
			if (l0) {
				if (Input.GetKeyDown (KeyCode.Space)||Input.GetKeyDown(KeyCode.Alpha1)) {
                    LINES(0, 1);
				}
			}
			if (l1) {
				if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.Comma)||Input.GetKeyDown(KeyCode.Alpha2)) {
                    LINES(1, 1);
				}
			}
			if (l2) {
				if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.L)||Input.GetKeyDown(KeyCode.Alpha3)) {
                    LINES(2, 1);
				}
			}
				
			if (l3) {			
				if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Period)||Input.GetKeyDown(KeyCode.Alpha4)) {
                    LINES(3, 1);
				}
			}
			if (l4) {
				if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.Semicolon)||Input.GetKeyDown(KeyCode.Alpha5)) {
                    LINES(4, 1);
				}
			}
			if (l5) {
                if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Slash) || Input.GetKeyDown(KeyCode.Alpha6))
                {
                    LINES(5, 1);
                }
			}
			if (l6) {
				if (Input.GetKeyDown (KeyCode.Colon) || Input.GetKeyDown (KeyCode.F)||Input.GetKeyDown(KeyCode.Alpha7)) {
                    LINES(6, 1);
                }
			}
			if (l7) {
				if (Input.GetKeyDown (KeyCode.V) || Input.GetKeyDown (KeyCode.Backslash) || Input.GetKeyDown (KeyCode.Underscore)||Input.GetKeyDown(KeyCode.Alpha8)) {
                    LINES(7, 1);
				}
			}
		}
	}

    //引数をキーの場合0、タップの場合1とする

    public void LINES(int line,int sw)
    {
        switch (line)
        {
            case 0:

                if (l00 == true)
                {
                    tap.Play();
                }
                l0 = false;
                Instantiate(LINE0);
                break;

            case 1:
                if (l01 == true)
                {
                    tap.Play();
                }
                l1 = false;
                Instantiate(LINE1);
                break;

            case 2:
                if (l02 == true)
                {
                    tap.Play();
                }
                l2 = false;
                Instantiate(LINE2);
                break;

            case 3:
                if (l03 == true)
                {
                    tap.Play();
                }
                l3 = false;
                Instantiate(LINE3);
                break;

            case 4:
                if (l04 == true)
                {
                    tap.Play();
                }
                l4 = false;
                Instantiate(LINE4);
                break;

            case 5:

                if (l05 == true)
                {
                    tap.Play();
                }
                l5 = false;
                Instantiate(LINE5);
                break;

            case 6:
                if (l06 == true)
                {
                    tap.Play();
                }
                l6 = false;
                Instantiate(LINE6);
                break;

            case 7:
                if (l07 == true)
                {
                    tap.Play();
                }
                l7 = false;
                Instantiate(LINE7);
                break;

            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            default:
                Debug.Log("Debug Error! tapEffect");
                break;
        }
    }
}
