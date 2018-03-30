using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    private float zForce;
    private float xForce;
    private float maxForce = 2000;
    private float minForce = -2000;
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



        ///
        ///something similar to this to get the z value of the mouse to show on a 2d plane as rotating the shot
        //Vector3.ProjectOnPlane(Input.mousePosition, Vector3.forward);
        ///



        //if (Input.GetMouseButton(0))
        //{
        //    updateLineRend();
        //}

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            xForce = Mathf.Clamp((startPos.x - endPos.x) * 3, minForce, maxForce);
            zForce = ((startPos.z - endPos.z) * SENSITIVITY);

            GetComponent<Rigidbody>().AddForce(new Vector3(xForce, 0f , zForce));

            init = true;
            zForce = 0;
            startPos = endPos = Vector3.zero;
            //updateLineRend();
        }
    }

    //private void updateLineRend() TODO: FIX MATH
    //{
    //    Vector3[] newPos = new Vector3[2];
    //    newPos[0] = transform.position;
    //    newPos[1] = transform.position+Vector3.ProjectOnPlane(Input.mousePosition, Vector3.forward);

    //    GetComponent<LineRenderer>().SetPositions(newPos);
    //}
}