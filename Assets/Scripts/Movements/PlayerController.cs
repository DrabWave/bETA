using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerStats pS;

    protected Vector3 movementVector;

    protected new Rigidbody rigidbody;
    protected Transform myTransform;

    public float RunningTime;
    private float _TimeOfRunning;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myTransform = transform;
        _TimeOfRunning = RunningTime;
    }


    protected void Update()
    {

        


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            pS.MoveSpeed *= 1.5f;
            
        }


        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            pS.MoveSpeed /= 1.5f;
            
            
        }



        movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        rigidbody.MovePosition(myTransform.position + movementVector * pS.MoveSpeed * Time.fixedDeltaTime);


        //Debug.Log(RunningTime);
        //Debug.Log(pS.MoveSpeed);

    }


    
}
