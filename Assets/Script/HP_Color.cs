using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Color : MonoBehaviour {
    Renderer color_;
    // Use this for initialization
    void Start()
    {

        color_ = GameObject.Find("Fill").GetComponent<Renderer>();
        color_.material.color = Color.green;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
