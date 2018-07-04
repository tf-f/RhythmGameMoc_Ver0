using UnityEngine;

public class GameInitial //: MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        //画面比率の強制固定
        Screen.SetResolution(1000,545, false, 80);

    }

    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}