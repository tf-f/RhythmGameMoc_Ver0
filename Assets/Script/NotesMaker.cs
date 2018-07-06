using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;


//This script Updated at 16:05 2018/02/26 完成
public class NotesMaker : MonoBehaviour
{
    public float L_Notes = 0.6f;

    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();

    //public AudioSource[] Musics;
    //private AudioSource MUSIC;
    //public AudioSource AS;
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
        //AS = GetComponent<AudioSource>();
        //AudioSource[] Audios = GetComponents<AudioSource>();
        //Musics[Base.MusicNumber] = Audios[Base.MusicNumber];
        //Musics = gameObject.GetComponents<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
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
        //終了処理
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WriteNotesTiming(99);
            SceneManager.LoadScene("HOME");
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isPlaying)
        {
            StartMusic();
        }

        if (_isPlaying)
        {
            DetectKeys();
        }
    }
    public void StartMusic()
    {
        startButton.SetActive(false);
        _startTime = Time.time;
        _isPlaying = true;

        //GetComponent<AudioSource>().clip = Musics[Base.MusicNumber];
        //GetComponent<AudioSource>().Play();
        //MUSIC.PlayOneShot(MUSIC.clip);
        //Musics[Base.MusicNumber].Play();
        // audio.PlayOneShot(Musics[Base.MusicNumber]);
        //Musics[Base.MusicNumber].PlayOneShot(Musics[Base.MusicNumber].clip);
        audioSource.PlayOneShot(audioClip[Base.MusicNumber]);

    }

    void DetectKeys()
    {
        //WriteNotesTiming(null);
        if (Input.GetKeyDown(KeyCode.Space))
        // キーの設定
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


        if (Input.GetKeyDown(KeyCode.C))
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
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
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


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
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


        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
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

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
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

