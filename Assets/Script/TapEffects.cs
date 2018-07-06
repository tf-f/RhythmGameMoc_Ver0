using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffects : MonoBehaviour {

    public GameObject gm;
    public GameObject[] Back_Effect;


    AudioSource audioSource;
    //効果音の収納
    public AudioClip tap;
    public AudioClip Perfect_Tap;
    public AudioClip Great_Tap;
    public AudioClip Bad_Tap;
    //public GameObject Long;

    
    // Use this for initialization
    void Start () {
        audioSource = gameObject.AddComponent<AudioSource>();
        /*
        tap = gameObject.GetComponent<AudioClip>();
        Perfect_Tap = gameObject.GetComponent<AudioClip>();
        Great_Tap = gameObject.GetComponent<AudioClip>();
        Bad_Tap = gameObject.GetComponent<AudioClip>();
        */
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
            audioSource.PlayOneShot(tap);
            Instantiate(Back_Effect[0]);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            audioSource.PlayOneShot(tap);
            Instantiate(Back_Effect[1]);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            audioSource.PlayOneShot(tap);
            Instantiate(Back_Effect[2]);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            audioSource.PlayOneShot(tap);
            Instantiate(Back_Effect[3]);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            audioSource.PlayOneShot(tap);
            Instantiate(Back_Effect[4]);
        }

    }

    public void Perfect_Tap_Play()
    {
        audioSource.PlayOneShot(Perfect_Tap);
    }
    public void Great_Tap_Play()
    {
        audioSource.PlayOneShot(Great_Tap);
    }
    public void Bad_Tap_Play()
    {
        audioSource.PlayOneShot(Bad_Tap);
    }
}
