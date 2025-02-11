using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerStats pS;

    protected Vector3 movementVector;

    protected new Rigidbody rigidbody;
    protected Transform myTransform;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myTransform = transform;
    }


    protected void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift)) pS.MoveSpeed *= 1.5f;
        if (Input.GetKeyUp(KeyCode.LeftShift)) pS.MoveSpeed /= 1.5f;




        movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        rigidbody.MovePosition(myTransform.position + movementVector * pS.MoveSpeed * Time.fixedDeltaTime);

    }


    
}
