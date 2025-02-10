using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]

    protected float movementSpeed = 6.0f;

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
        movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        rigidbody.MovePosition(myTransform.position + movementVector * movementSpeed * Time.fixedDeltaTime);

    }


    
}
