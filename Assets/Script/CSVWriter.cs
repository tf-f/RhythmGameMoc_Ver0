using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;  // <- ここに注意

public class CSVWriter : MonoBehaviour
{

    public string fileName; // 保存するファイル名
    public string[] database;//[] = new string ;

    void Start () {
        try
        {

            fileName = Base.MusicNumber.ToString() + Base.MusicLevel.ToString();

        }
        catch
        {
            Debug.Log("Null reference Error!");
            SceneManager.LoadScene("Error");
        }
	}

    // CSVに書き込む処理
    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        //DetaPathをCSV/で固定
        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".csv");
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(txt);
        streamWriter.Flush();
        streamWriter.Close();
    }
}
