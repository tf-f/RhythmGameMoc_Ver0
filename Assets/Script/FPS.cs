using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    int frameCount;
    float prevTime;
    public Text SHOWFPS;
    

    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    void Update()
    {
        //どっちか  
        float fps = 1f / Time.deltaTime;
        Debug.LogFormat("{0}fps", fps);

        ++frameCount;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            Debug.LogFormat("{0}fps", frameCount / time);

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }

        SHOWFPS.text ="FPS: " + (((int)(fps*10))/10.0).ToString();
    }
}