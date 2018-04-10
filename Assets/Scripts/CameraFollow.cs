using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ballObbj;


    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(ballObbj.GetComponent<Rigidbody>().velocity.x, 0, ballObbj.GetComponent<Rigidbody>().velocity.z);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cup 1")
        {
            Debug.Log("Completed");
            transform.position = ballObbj.position;
        }
    }
}