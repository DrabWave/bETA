using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // ����� ������� �������, *�������� � �������


    [SerializeField]
    public PlayerStats pS;

    public Vector3 movementVector;

    protected new Rigidbody rigidbody;
    protected Transform myTransform;

    public Sounds sos;


    private float MaxMoveSpeed; 
    private float MinMoveSpeed;

    private float CrowMoveSpeed;
    public bool isCrowing;

    public float maxStamina;    
    public float currentStamina;        
    public float staminaRecoveryDelay; 
    private float lastStaminaUseTime;
    public bool isRunning;

    public bool canSprint;

    public GameObject PrefabAudio;
    public int time, moveTime;


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
        canSprint = true;

        StayCameraPosition.transform.position = cameraPosition.transform.position;
        //_current_cameraPosition = new Vector3(cameraPosition.transform.position.x, cameraPosition.transform.position.y, cameraPosition.transform.position.z);
    }


    public void Update()
    {
        Sprint();
        Crawl();
        


        //Debug.Log(pS.MoveSpeed);

        movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        rigidbody.MovePosition(myTransform.position + movementVector * pS.MoveSpeed * Time.fixedDeltaTime);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (time != 0) return;
            time = moveTime;

            GameObject _temp = Instantiate(PrefabAudio);
            _temp.GetComponent<AudioSource>().clip = sos.sounds[0];
            _temp.GetComponent<AudioSource>().Play();
            Destroy(_temp, 0.8f);

        }




    }

    private void FixedUpdate()
    {
        if (time > 0)
        {
            time--;
        }
    }



    private void Sprint()
    {
        if (canSprint == true)
        {
            if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
            {
                pS.MoveSpeed = MaxMoveSpeed;


                currentStamina -= Time.deltaTime;
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
