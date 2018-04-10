using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey("a"))
        {
            Debug.Log("pressed");
            transform.Rotate(0, 0 , 1);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 0, -1);
        }
	}
}
