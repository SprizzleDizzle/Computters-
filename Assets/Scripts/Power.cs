using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    private float zForce;
    private float xForce;
    private float maxForce = 5000;
    private float minForce = 0;
    private Vector3 startPos;
    private Vector3 endPos;
    private float originX;
    private bool init = true;
    private LineRenderer LR;

    public float SENSITIVITY = 300;

    void start()
    {
        GetComponent<Rigidbody>().useGravity = true;
        LR = GetComponent<LineRenderer>();

    }

    void Update()
    {
        originX = transform.position.x;

        if (Input.GetMouseButtonDown(0))
        {
            if (init)
            {
                startPos = Input.mousePosition;
                init = false;
            }
        }

    

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            xForce = Mathf.Clamp((startPos.x - endPos.x) * 3, minForce, maxForce);
          

            GetComponent<Rigidbody>().AddForce(new Vector3(xForce, 0f , zForce));

            init = true;
            xForce = 0;
            startPos = endPos = Vector3.zero;
            
        }
    }


}