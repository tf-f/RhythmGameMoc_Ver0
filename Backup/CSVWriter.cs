using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;  // <- ここに注意

public class CSVWriter : MonoBehaviour
{

    public string fileName; // 保存するファイル名

    void Start()
    {
		switch (MenuManager2.music_select){
		case 0:
			//test後削除
			//_audioSource = GameObject.Find("Only My Railgun short").GetComponent<AudioSource>();
			fileName = "Nousyou";
			break;
		case 1:
			fileName = "OnlyMyRailgun";
				break;
		case 2:
			fileName = "Maware";
			break;
		case 3:
			fileName = "ElementalCreation";
			break;
		case 4:
			fileName = "Senbonzakura";
			break;
		case 5:
			fileName = "FutureGazer";
			break;
		case 6:
			fileName = "Daisuke";
			break;
		case 7:
			fileName = "ERRORCODE";
			break;
		case 8:
			fileName = "Contrapasso";
			break;
		case 9: 
			fileName = "PARANOiA";
			break;
		case 10:
			fileName = "ECHO";
			break;
		case 11:
			fileName = "LEVEL5";
			break;
		case 12:
			fileName = "beach";
			break;
		case 13:
			fileName = "hesitation";
			break;
		case 14:
			fileName = "asuno";
			break;
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
                fileName = "Empty";
                break;
		default:
			break;
	
		}

        if(fileName == "Empty")
        {
            SceneManager.LoadScene("Home");
        }
		fileName += Selecter_selectLevel.Level_.ToString ();
		//fileName;


    }
    // CSVに書き込む処理

    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".csv");
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(txt);
        streamWriter.Flush();
        streamWriter.Close();
    }
}
