using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffects : MonoBehaviour {

    public GameObject gm;
    public GameObject LINE0;
    public GameObject LINE1;
    public GameObject LINE2;
    public GameObject LINE3;
    public GameObject LINE4;
    public GameObject LINE5;



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
    [SerializeField] ParticleSystem tapEffect;              // タップエフェクト
    [SerializeField] Camera _camera;                        // カメラの座標

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスのワールド座標までパーティクルを移動し、パーティクルエフェクトを1つ生成する
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
            tapEffect.transform.position = pos;
            tapEffect.Emit(1);
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
