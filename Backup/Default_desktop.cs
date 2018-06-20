using UnityEngine;

public class GameInitial //: MonoBehaviour
{
	[RuntimeInitializeOnLoadMethod]
	static void OnRuntimeMethodLoad()
	{
		Screen.SetResolution( 1400, 700, false, 80);

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