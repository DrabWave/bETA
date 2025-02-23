using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerStats pS;

    protected Vector3 movementVector;

    protected new Rigidbody rigidbody;
    protected Transform myTransform;


    private float MaxMoveSpeed; // ������������ �������� ������������
    private float MinMoveSpeed; // ����������� �������� ������������

    private float maxStamina = 10f;    // ������������ �������
    public float currentStamina;        // ������� �������
    private float staminaRecoveryDelay = 1f; // �������� ����� ��������������� ������� ����� �������������
    private float lastStaminaUseTime; // ����� ���������� ������������� �������

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
