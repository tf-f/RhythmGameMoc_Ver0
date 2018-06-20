using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


//This script Updated at 16:05 2018/02/26 完成
public class NotesMaker : MonoBehaviour
{
    public float L_Notes = 0.3f;
    public AudioSource[] Musics;
    //    private AudioSource **;
    private float _startTime = 0;
    private float _timer = 0;
    public CSVWriter _CSVWriter;

    private bool _isPlaying = false;
    public GameObject startButton;

    public float[] note_time;

    // Use this for initialization
    void Start()
    {
        _isPlaying = false;
        _timer = 0;
        try
        {
            _CSVWriter = _CSVWriter.GetComponent<CSVWriter>();

        }
        catch
        {
            Debug.Log("Error! Not find file or music");
            SceneManager.LoadScene("Error");
        }

        note_time = new float[20];

    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_isPlaying)
        {
            DetectKeys();
        }
        //終了処理
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WriteNotesTiming(99);
            SceneManager.LoadScene("HOME");
        }

    }
    public void StartMusic()
    {
        startButton.SetActive(false);

        _startTime = Time.time;
        _isPlaying = true;
    }

    void DetectKeys()
    {
        //WriteNotesTiming(null);
        if (Input.GetKeyDown(KeyCode.Space)) // キーの設定
        {
            note_time[0] = GetTiming();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (GetTiming() - note_time[0] >= L_Notes)
            {
                WriteNotesTiming(10);
            }
                else
            {
                WriteNotesTiming(0);
            }
            note_time[0] = 0;
        }


        if (Input.GetKeyUp(KeyCode.C))
        {
            note_time[1] = GetTiming();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (GetTiming() - note_time[1] >= L_Notes)
            {
                WriteNotesTiming(11);
            }
            else
            {
                WriteNotesTiming(1);
            }
            note_time[1] = 0;
        }


        if (Input.GetKeyDown(KeyCode.V))
        {
            note_time[2] = GetTiming();
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            if (GetTiming() - note_time[2] >= L_Notes) { 
                WriteNotesTiming(12);
            }
            else
            {
                WriteNotesTiming(2);
            }
            note_time[2] = 0;
        }

        
        if (Input.GetKeyDown(KeyCode.N))
        {
            note_time[3] = GetTiming();
        }
        if(Input.GetKeyUp(KeyCode.N)){
            if (GetTiming() - note_time[3] >= L_Notes)
            {
                WriteNotesTiming(13);
            }
            else
            {
                WriteNotesTiming(3);
            }
            note_time[3] = 0;
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            note_time[4] = GetTiming();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            if(GetTiming() - note_time[4] >= L_Notes)
            {
                WriteNotesTiming(14);
            }
            else
            {
                WriteNotesTiming(4);
            }
            note_time[4] = 0;
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            note_time[5] = GetTiming();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if(GetTiming() - note_time[5] >= L_Notes)
            {
                WriteNotesTiming(15);
            }
            else
            {
                WriteNotesTiming(5);
            }
            note_time[5] = 0;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            note_time[6] = GetTiming();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (GetTiming() - note_time[6] >= L_Notes)
            {
                WriteNotesTiming(16);
            }
            else
            {
                WriteNotesTiming(6);
            }
            note_time[6] = 0;
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            note_time[7] = GetTiming();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (GetTiming() - note_time[7] >= L_Notes)
            {
                WriteNotesTiming(17);
            }
            else
            {
                WriteNotesTiming(7);
            }
            note_time[7] = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            note_time[8] = GetTiming();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (GetTiming() - note_time[8] >= L_Notes)
            {
                WriteNotesTiming(18);
            }
            else
            {
                WriteNotesTiming(8);
            }
            note_time[8] = 0;
        }


    }

    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());
        if (num < 10)
        {
            _CSVWriter.WriteCSV(GetTiming().ToString() + "," + num.ToString());
        }
        else
        {
            _CSVWriter.WriteCSV((GetTiming() - note_time[num]).ToString() + "," + num.ToString());
            _CSVWriter.WriteCSV(GetTiming().ToString() + "," + (num-10).ToString());
        }
    }

    float GetTiming()
    {
        return Time.time - _startTime;
    }

}

