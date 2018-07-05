using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffects : MonoBehaviour {

    public GameObject gm;
    public GameObject[] Back_Effect;



    //効果音の収納
    public AudioSource tap;
    public AudioSource Perfect_Tap;
    public AudioSource Great_Tap;
    public AudioSource Bad_Tap;
    //public GameObject Long;

    
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    //    [SerializeField] ParticleSystem tapEffect;              // タップエフェクト
    //    [SerializeField] Camera _camera;                        // カメラの座標

    void Update()
    {
        {
            /*
                    if (Input.GetMouseButtonDown(0))
                    {
                        // マウスのワールド座標までパーティクルを移動し、パーティクルエフェクトを1つ生成する
                        var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
                        tapEffect.transform.position = pos;
                        tapEffect.Emit(1);
                    }
            */

        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftArrow)
            || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(Back_Effect[0]);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(Back_Effect[1]);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(Back_Effect[2]);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(Back_Effect[3]);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(Back_Effect[4]);
        }

    }

    public void Perfect_Tap_Play()
    {
        Perfect_Tap.Play();
    }
    public void Great_Tap_Play()
    {
        Great_Tap.Play();
    }
    public void Bad_Tap_Play()
    {
        Bad_Tap.Play();
    }
}
