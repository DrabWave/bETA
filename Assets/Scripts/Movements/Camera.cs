using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.Rendering;

public class Camera : MonoBehaviour
{

    public float sentivity;
    private float _sentivity_current;
    public float maxYAngle = 80.0f;

    private float rotationX = 0.0f;
    private Vector3 _startPos;
    public float _distation;
    private Vector3 _rotation;
    public float amount;
    public float speed;
    internal Color backgroundColor;

    void Start()
    {

        Cursor.visible = false;
        _sentivity_current = sentivity;

    }


    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        transform.parent.Rotate(Vector3.up * mouseX * sentivity);


        rotationX -= mouseY * sentivity;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);




    }

    internal Vector3 WorldToViewportPoint(Vector3 position)
    {
        throw new NotImplementedException();
    }

    public void StopSentivity(bool isSentivity) // stopping game screen when we are using EscapeMenu
    {
        if (isSentivity == true) sentivity *= 0;
        else sentivity = _sentivity_current;
    }
}
