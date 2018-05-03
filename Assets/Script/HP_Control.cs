using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HP_Control : MonoBehaviour
{
    Slider _slider;
    public GameObject gm;
    float _hp = 0;
    // Use this for initialization
    void Start()
    {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        _hp = gm.GetComponent<GameManage>().Life/100.0f;

    }

    // Update is called once per frame
    void Update()
    {
        _hp = gm.GetComponent<GameManage>().Life / 100.0f;
        _slider.value = _hp;

    }
}
