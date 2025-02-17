using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerStats pS;

    protected Vector3 movementVector;

    protected new Rigidbody rigidbody;
    protected Transform myTransform;
    public float RunningTime = 10f;

    private float MaxMoveSpeed;
    private float MinMoveSpeed;

    private float MaxRunningTime;
    private float MinRunningTime;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myTransform = transform;
        MaxMoveSpeed = pS.MoveSpeed * 1.5f;
        MinMoveSpeed = pS.MoveSpeed;
        MaxRunningTime = RunningTime;
        MinRunningTime = 0;
    }


    protected void Update()
    {

        


        if (Input.GetKey(KeyCode.LeftShift) && RunningTime > 0)
        {

            pS.MoveSpeed *= 1.5f;
            if (pS.MoveSpeed > MaxMoveSpeed) pS.MoveSpeed = MaxMoveSpeed;
            RunningTime-= Time.deltaTime;
            if (RunningTime < MinRunningTime) RunningTime = MinRunningTime;
            
        }


        if (((!Input.GetKey(KeyCode.LeftShift)) || RunningTime == 0))
        {
            pS.MoveSpeed /= 1.5f;
            if (pS.MoveSpeed < MinMoveSpeed) pS.MoveSpeed = MinMoveSpeed;
            RunningTime += Time.deltaTime;
            if (RunningTime > MaxRunningTime) RunningTime = MaxRunningTime;
        }



        Debug.Log(pS.MoveSpeed);

        movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        rigidbody.MovePosition(myTransform.position + movementVector * pS.MoveSpeed * Time.fixedDeltaTime);



    }


    
}
