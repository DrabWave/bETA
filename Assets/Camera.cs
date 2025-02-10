using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]

    public float sentivity = 1f;
    public float smooth = 10f;

    public Transform character;

    private float yRotation;
    private float xRotation;




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
}
