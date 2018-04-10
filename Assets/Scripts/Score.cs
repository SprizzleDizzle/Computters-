using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int strokeCount = 0;
    Text stroke;
    
	// Use this for initialization
	void Start ()
    {
        stroke = GetComponent<Text>();	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        stroke.text = "Storke:" + strokeCount;
	}
}
