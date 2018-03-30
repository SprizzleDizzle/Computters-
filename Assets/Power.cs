using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    private float yForce;
    private float xForce;
    private float maxForceXp = 2000;
    private float maxForceXm = 2000;
    private float startPosX;
    private float endPosX;
    private float originX;
    private float startRotateZ;
  



    void Update()
    {
        originX = GetComponent<Rigidbody>().position.x;

        if (Input.GetMouseButtonDown(0))
        {
            startPosX = Input.mousePosition.x;
            startRotateZ = Input.mousePosition.z;
           
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPosX = Input.mousePosition.x;
            xForce = (startPosX - endPosX) * 3;

            if (xForce > 0 && xForce > maxForceXp) xForce = maxForceXp;

            if (xForce < 0 && xForce < maxForceXm) xForce = maxForceXm;

            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(new Vector2(xForce, yForce));

            yForce = 0;
            startPosX = 0;
            endPosX = 0;
           
        }
    }
}