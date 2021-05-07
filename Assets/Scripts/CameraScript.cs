using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float rotationY = 0.0f;
    private float rotationZ = 0.0f;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print("X: " + Input.GetAxis("Mouse X") + " | Y: " + Input.GetAxis("Mouse Y"));
        if(rotationY <= 50f && rotationY >= -50f /*|| rotationY >= 310f*/)
        {
            rotationY += speedH * Input.GetAxis("Mouse X");
        }
        else if(rotationY > 50f && rotationY < 180f)
        {
           rotationY = 49.99f;
        }
        else if(rotationY < -50f && rotationY > -180f) //  nuo -50 iki -180
        {
            rotationY = -49.9f;
        }
        if(rotationZ <= 25f && rotationZ >= -8f) 
        {
            rotationZ += speedV * Input.GetAxis("Mouse Y");
        }
        else if(rotationZ > 25f && rotationZ < 180f)
        {
           rotationZ = 24.99f;
        }
        else if(rotationZ < -8f && rotationZ > -180f)
        {
            rotationZ = -7.99f;
        }
        //print("Y: " + rotationY + " | Z:" + rotationZ);
        transform.rotation = Quaternion.Euler(0, rotationY, rotationZ);
        // }
        //transform.localRotation = Quaternion.Euler (currentRotation);
    }
}
