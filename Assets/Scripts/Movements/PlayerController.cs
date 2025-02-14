using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerStats pS;

    protected Vector3 movementVector;

    protected new Rigidbody rigidbody;
    protected Transform myTransform;

    public float RunningTime;

    private float _stamina;
    private float _runningSpeed;
    private float _standartSpeed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myTransform = transform;
        _stamina = RunningTime;
        _standartSpeed = pS.MoveSpeed;
        _runningSpeed = _standartSpeed * 1.5f;
    }


    protected void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _stamina > 0)
        {
            //pS.MoveSpeed *= 1.5f;
            _standartSpeed = _runningSpeed;
            _stamina -= Time.deltaTime;

        }


        if (!(Input.GetKey(KeyCode.LeftShift)) && _stamina >= 0)
        {
            _standartSpeed = pS.MoveSpeed;
            _stamina += Time.deltaTime;   
        }
        StaminaLimit();


        movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        rigidbody.MovePosition(myTransform.position + movementVector * _standartSpeed * Time.fixedDeltaTime);


        //Debug.Log(RunningTime);
        Debug.Log(_standartSpeed);
        //Debug.Log($"Stamina - {_stamina}");

    }


    private void StaminaLimit()
    {

        if (_stamina > RunningTime) _stamina = RunningTime;
        if (_stamina < 0) _stamina = 0;

        
    }
}
