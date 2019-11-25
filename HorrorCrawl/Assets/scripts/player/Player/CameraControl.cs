﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    //Rotation Sensitivity
    public float RotationSensitivity = 35.0f;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;

    //Rotation Value
    float yRotate = 0.0f;
    float xRotate = 0.0f;
    // Update is called once per frame
    void Update()
    {

        //Rotate Y view
        yRotate -= Input.GetAxis("Mouse Y") * RotationSensitivity * Time.deltaTime;
        yRotate = Mathf.Clamp(yRotate, minAngle, maxAngle);

        //Rotate X view
        xRotate += Input.GetAxis("Mouse X") * RotationSensitivity * Time.deltaTime;
        xRotate = Mathf.Clamp(xRotate, minAngle, maxAngle);
        transform.eulerAngles = new Vector3(yRotate, xRotate, 0.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
