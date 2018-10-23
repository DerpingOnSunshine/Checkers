using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written and configured by Mitchell Augustus Parrish 10/22/2018

public class CameraControl : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 5.0f; //Minimum camera angle (y)
    private const float Y_ANGLE_MAX = 50.0f; //Maximum camera angle (y)

    public Transform lookAt; //Game object to look at
    public Transform camTransform; //Camera's transform component
    public float distance = 10.0f; //Distance of camera from object
    public float distance_MIN; //Minimum distance of camera from object
    public float distance_MAX; //Maximum distance of camera from object
    public float zoomSpeed = .25f; //Zoom speed

    private float currentX = 0.0f; //Angle of camera (x)
    private float currentY = 45.0f; //Angle of camera (y)
    public float sensitivityX = 4.0f; //Speed of change of (x) angle
    public float sensitivityY = 1.0f; //Speed of change of (y) angle

    private void Start()
    {
        camTransform = transform; //Forgot what this was for
    }

    private void Update()
    {
        if(Input.GetKey("up")) //Change (y) angle of camera
        {
            currentY += sensitivityY * Time.deltaTime; 
        }

        if (Input.GetKey("down")) //Change (y) angle of camera
        {
            currentY -= sensitivityY * Time.deltaTime;
        }

        if (Input.GetKey("left")) //Change (x) angle of camera
        {
            currentX -= sensitivityX * Time.deltaTime;
        }

        if (Input.GetKey("right")) //Change (x) angle of camera
        {
            currentX += sensitivityX * Time.deltaTime;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f ) //Zoom in (or out)
        {
            distance += zoomSpeed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //Zoom out (or in)
        {
            distance -= zoomSpeed;
        }

        //currentX += Input.GetAxis("Mouse X");
        //currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX); //Prevent camera angle from exceeding limits
        distance = Mathf.Clamp(distance, distance_MIN, distance_MAX); //Prevent camera distance from exceeding limits
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance); //Not sure
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0); //Don't remember
        camTransform.position = lookAt.position + rotation * dir; //Position of camera
        camTransform.LookAt(lookAt.position); //Look at the object
    }
}
