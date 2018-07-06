using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text SHOWFPS;
    float time;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        //どっちか  
        float fps = 1f / Time.deltaTime;
        time += Time.deltaTime;
        if (time >= 3.0f)
        {
            time = 0;
            SHOWFPS.text ="FPS: " + (((int)(fps*10))/10.0).ToString();
        }

    }
}
/*
    int frameCount;
    float prevTime;
        frameCount = 0;
        prevTime = 0.0f;
            Debug.LogFormat("{0}fps", frameCount / time);

            frameCount = 0;
        Debug.LogFormat("{0}fps", fps);

        ++frameCount;
        float time = Time.realtimeSinceStartup - prevTime;

            prevTime = Time.realtimeSinceStartup;
            */