using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Стелс систему сделать, *обсудить с Матвеем


    [SerializeField]
    public PlayerStats pS;

    protected Vector3 movementVector;

    protected new Rigidbody rigidbody;
    protected Transform myTransform;


    private float MaxMoveSpeed; 
    private float MinMoveSpeed;

    private float CrowMoveSpeed;
    public bool isCrowing;

    public float maxStamina;    
    public float currentStamina;        
    public float staminaRecoveryDelay; 
    private float lastStaminaUseTime;
    public bool isRunning;


    public GameObject cameraPosition;
    public GameObject CrowlCameraPosition;
    public GameObject StayCameraPosition;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        myTransform = transform;
        MaxMoveSpeed = pS.MoveSpeed * 1.5f;
        MinMoveSpeed = pS.MoveSpeed;
        currentStamina = maxStamina;       
        CrowMoveSpeed = pS.MoveSpeed / 2f;
        
        isRunning = false;
        isCrowing = false;



        StayCameraPosition.transform.position = cameraPosition.transform.position;
        //_current_cameraPosition = new Vector3(cameraPosition.transform.position.x, cameraPosition.transform.position.y, cameraPosition.transform.position.z);
    }


    protected void Update()
    {
        Sprint();
        Crawl();
       

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
            isRunning = true;


        }
        else
        {
            isRunning = false;
            pS.MoveSpeed = MinMoveSpeed;
            if (Time.time >= lastStaminaUseTime + staminaRecoveryDelay)
            {
                
                currentStamina += Time.deltaTime;
                
            }
        }
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    private void Crawl()
    {
        if (Input.GetKey(KeyCode.C) && isRunning == false)
        {
            isCrowing = true;
            cameraPosition.transform.position = CrowlCameraPosition.transform.position;
            pS.MoveSpeed = CrowMoveSpeed;
        }
        else
        {
            cameraPosition.transform.position = StayCameraPosition.transform.position;
            isCrowing = false;
        }
    }






    
}
