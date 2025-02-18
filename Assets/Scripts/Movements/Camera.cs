using UnityEngine;

public class Camera : MonoBehaviour
{
    public float sentivity = 2.0f;
    public float maxYAngle = 80.0f;
    public float amount;
    public float speed;
    
    private float _rotationX = 0.0f;
    private float _distation;
    private Vector3 _startPos;
    private Vector3 _rotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _startPos = transform.position; 
    }


    void Update()
    {
        // Поворот камеры

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        transform.parent.Rotate(Vector3.up * mouseX * sentivity);


        _rotationX -= mouseY * sentivity;
        //_rotationX = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);

        // Тряска камеры

        _distation += (transform.position - _startPos).magnitude;
        _startPos = transform.position;
        _rotation.z = Mathf.Sin(_distation * speed) * amount;
        _rotation.x = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
        transform.localEulerAngles = _rotation;
    }
}
