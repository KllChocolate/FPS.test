using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public float RotationSensitivity = 0.9f;

    float RotationMin = -40;
    float RotationMax = 80;

    public bool enableMobileInputs = true;
    public FixedTouchField touchField;
    public Transform target;

    private void LateUpdate()
    {
        if (enableMobileInputs) 
        {
            Yaxis += touchField.TouchDist.x * RotationSensitivity;
            Xaxis -= touchField.TouchDist.y * RotationSensitivity;
        }
    
        else 
        {
            Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
            Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
        }
        

        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);

        Vector3 tragetRotation = new Vector3(Xaxis, Yaxis);

        transform.eulerAngles = tragetRotation;

        transform.position = target.position - transform.forward * 2;
    }
}
