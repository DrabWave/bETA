using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerStats pS;

    protected Vector3 movementVector;

    protected new Rigidbody rigidbody;
    protected Transform myTransform;


    private float MaxMoveSpeed; // максимальная скорость передвижения
    private float MinMoveSpeed; // минимальная скорость передвижения

    private float maxStamina = 10f;    // максимальная стамина
    public float currentStamina;        // текущая стамина
    private float staminaRecoveryDelay = 1f; // задержка перед восстановлением стамины после использования
    private float lastStaminaUseTime; // время последнего использования стамины

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myTransform = transform;
        MaxMoveSpeed = pS.MoveSpeed * 1.5f;
        MinMoveSpeed = pS.MoveSpeed;
        currentStamina = maxStamina;
    }


    protected void Update()
    {
        Sprint();
       

        //Debug.Log(pS.MoveSpeed);

        movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        rigidbody.MovePosition(myTransform.position + movementVector * pS.MoveSpeed * Time.fixedDeltaTime);



    }


    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {

            pS.MoveSpeed = MaxMoveSpeed;
            currentStamina -=  Time.deltaTime;
            lastStaminaUseTime = Time.time; 


        }
        else
        {
            pS.MoveSpeed = MinMoveSpeed;
            if (Time.time >= lastStaminaUseTime + staminaRecoveryDelay)
            {
                
                currentStamina += Time.deltaTime;
            }

        }
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);








    }






    
}
