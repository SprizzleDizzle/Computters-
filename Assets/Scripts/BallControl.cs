using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BallControl : MonoBehaviour {

    private float minForce = 50;
    private float maxForce = 1500;
    private float xForce;
    private float zForce;
    private Vector3 startPosX;
    private Vector3 endPosX;
    private Vector3 startPosZ;
    private Vector3 endPosz;
    private float originX;
    private bool init = true;
    private LineRenderer LR;
    public Transform spawnHole2;
    public Slider power;



    void Start()
    {
        GetComponent<Rigidbody>().useGravity = true;
        LR = GetComponent<LineRenderer>();
        power.maxValue = maxForce;
        power.minValue = minForce;
        


    }

    void Update()
    {
        originX = GetComponent<Rigidbody>().position.x;

        if (Input.GetMouseButtonDown(0))
        {
            startPosX = Input.mousePosition;
            startPosZ = Input.mousePosition;
            



        }

        if (Input.GetMouseButtonUp(0))
        {
            Score.strokeCount += 1;
            endPosX = Input.mousePosition;
            xForce = Mathf.Clamp((startPosX.x - endPosX.x) * 3, minForce, maxForce);


            GetComponent<Rigidbody>().AddForce(new Vector3(xForce, 0f, zForce));

            init = true;
            zForce = 0;
            xForce = 0;
            startPosX = endPosX = Vector3.zero;
        }

        if (Input.GetKey("a"))
        {
            Debug.Log("pressed");
            transform.Rotate(0, -1, 0);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 1, 0);
        }


    }

    public void OnMove(AxisEventData eventData)
    {
        // override the slider value using our previousSliderValue and the desired step
        if (eventData.moveDir == MoveDirection.Down)
        {
            power.value =+ 1;
        }
      
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cup 1")
        {
            Debug.Log("Completed");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.position = spawnHole2.position;
            Score.strokeCount = 0;

        }
       
    }
}
