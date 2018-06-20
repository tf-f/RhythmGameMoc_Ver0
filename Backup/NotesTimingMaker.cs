using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NotesTimingMaker : MonoBehaviour
{

    private AudioSource _audioSource;
    private AudioSource _Nousyou;
    private AudioSource _OnlyMyRailgun;
    private AudioSource _Maware;
    private AudioSource _ElementalCreation;
    private AudioSource _Senbon;
    private AudioSource _FutureGazer;
    private AudioSource _errorcode;
    private AudioSource _contrapasso;
    private AudioSource _echo;
    private AudioSource _daisuke;
    private AudioSource _paranoia;
    private AudioSource _syakunetsu;
    private AudioSource _hesitation;
    private AudioSource _asuno;
    private AudioSource _level5;
    //    private AudioSource **;

    private float _startTime = 0;
    private CSVWriter _CSVWriter;

    private bool _isPlaying = false;
    public GameObject startButton;

    void Start()
    {
        try {

            switch (MenuManager2.music_select) {
                case 0:
                    //test後削除
                    //_audioSource = GameObject.Find("Only My Railgun short").GetComponent<AudioSource>();
                    _Nousyou = GameObject.Find("Nousyou").GetComponent<AudioSource>();
                    break;
                case 1:
                    _OnlyMyRailgun = GameObject.Find("OnlyMyRailgun").GetComponent<AudioSource>();
                    break;
                case 2:
                    _Maware = GameObject.Find("Maware").GetComponent<AudioSource>();
                    break;
                case 3:
                    _ElementalCreation = GameObject.Find("ElementalCreation").GetComponent<AudioSource>();
                    break;
                case 4:
                    _Senbon = GameObject.Find("Senbonzakura").GetComponent<AudioSource>();
                    break;
                case 5:
                    _FutureGazer = GameObject.Find("FutureGazer").GetComponent<AudioSource>();
                    break;
                case 6:
                    _daisuke = GameObject.Find("Daisuke").GetComponent<AudioSource>();
                    break;
                case 7:
                    _errorcode = GameObject.Find("ERROR CODE").GetComponent<AudioSource>();
                    break;
                case 8:
                    _contrapasso = GameObject.Find("Contrapasso").GetComponent<AudioSource>();
                    break;
                case 9:
                    _paranoia = GameObject.Find("PARANOiA").GetComponent<AudioSource>();
                    break;
                case 10:
                    _echo = GameObject.Find("ECHO").GetComponent<AudioSource>();
                    break;
                case 11:
                    _level5 = GameObject.Find("LEVEL5").GetComponent<AudioSource>();
                    break;
                case 12:
                    _syakunetsu = GameObject.Find("syakunetsu").GetComponent<AudioSource>();
                    break;
                case 13:
                    _hesitation = GameObject.Find("Hesitation Snow").GetComponent<AudioSource>();
                    break;
                case 14:
                    _asuno = GameObject.Find("asunoyozora").GetComponent<AudioSource>();
                    break;
                default:
                    break;

            }

            _CSVWriter = GameObject.Find("CSVWriter").GetComponent<CSVWriter>();

        } catch {
            SceneManager.LoadScene("Catch Null");
        }

    }

    void Update()
    {
        if (_isPlaying)
        {
            DetectKeys();
        }
        //終了処理
        if (Input.GetKeyDown(KeyCode.Q)) {
            WriteNotesTiming(8);
            SceneManager.LoadScene("HOME");
        }
    }

    public void StartMusic()
    {
        startButton.SetActive(false);
        switch (MenuManager2.music_select) {
            case 0:
                //_audioSource.Play ();
                //テスト後削除
                _Nousyou.Play();
                break;
            case 1:
                _OnlyMyRailgun.Play();
                break;
            case 2:
                _Maware.Play();
                break;
            case 3:
                _ElementalCreation.Play();
                break;
            case 4:
                _Senbon.Play();
                break;
            case 5:
                _FutureGazer.Play();
                break;
            case 6:
                _daisuke.Play();
                break;
            case 7:
                _errorcode.Play();
                break;
            case 8:
                _contrapasso.Play();
                break;
            case 9:
                _paranoia.Play();
                break;
            case 10:
                _echo.Play();
                break;
            case 11:
                _level5.Play();
                break;
            case 12:
                _syakunetsu.Play();
                break;
            case 13:
                _hesitation.Play();
                break;
            case 14:
                _asuno.Play();
                break;
            default:
                break;

        }

        _startTime = Time.time;
        _isPlaying = true;
    }

    void DetectKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // キーの設定
        {
            WriteNotesTiming(0);
        }
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Comma))
        {
            WriteNotesTiming(1);
        }
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Period))
        {
            WriteNotesTiming(3);
            {
            }
            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Slash))
            {
                WriteNotesTiming(5);
            }
            if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.Backslash) || Input.GetKeyDown(KeyCode.Underscore))
            {
                WriteNotesTiming(7);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.L))
            {
                WriteNotesTiming(2);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Semicolon))
            {
                WriteNotesTiming(4);
            }
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Colon))
            {
                WriteNotesTiming(6);
            }

        }
    }

    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());
        _CSVWriter.WriteCSV(GetTiming().ToString() + "," + num.ToString());
    }

    float GetTiming()
    {
        return Time.time - _startTime;
    }

}   