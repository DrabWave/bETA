using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.Rendering;

public class Camera : MonoBehaviour
{
    /*
    [SerializeField]

    public float sentivity = 1f;
    public float smooth = 0.1f;

    public Transform character;

    private float yRotation;
    private float xRotation;
    internal static Camera main;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * sentivity * Time.deltaTime;
        xRotation -= Input.GetAxis("Mouse Y") * sentivity * Time.deltaTime;


        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        RotateCharater();

    }


    protected void RotateCharater()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * smooth);
        character.rotation = Quaternion.Lerp(character.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime * smooth);
    }

    internal Ray ScreenPointToRay(Vector3 mousePosition)
    {
        throw new NotImplementedException();
    }
    */

    public float sentivity;
    public float maxYAngle = 80.0f;

    private float rotationX = 0.0f;
    private Vector3 _startPos;
    public float _distation;
    private Vector3 _rotation;
    public float amount;
    public float speed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
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






}
