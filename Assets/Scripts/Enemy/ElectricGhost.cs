using UnityEngine;

public class ElectricGhost : MonoBehaviour
{
    // Ёлектрический призрак: Ќевидимый монстр, который создаЄт электрические разр€ды, временно парализу€ игрока.
    // задача: тр€ска камеры при стане

    public Enemies E;
    public PlayerStats pS;
    public Camera Canera;

    public float TimeOfStan;
    public float Step;

    private Transform _positionElectricGhost;
    private bool _isStan;
    private float _First_TimeOfStan;
    private float _First_MoveSpeed;
    private float _First_SensivirtOfCamera;
    //private Vector3 _First_PositionOfCamera;


    private void Start()
    {
        _positionElectricGhost = transform;
        _isStan = false;

        _First_MoveSpeed = pS.MoveSpeed;
        _First_TimeOfStan = TimeOfStan;
        //_First_PositionOfCamera = new Vector3(Canera.transform.rotation.x, Canera.transform.rotation.y, Canera.transform.rotation.z);
    }

    private void Update()
    {
        E.GoingToPlayer(_positionElectricGhost, Step);

        if ( _isStan == true)
        {
            Stan();
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
       {
            E.TeleportEnemy(_positionElectricGhost);
            _isStan = true;

            pS.MoveSpeed *= 0;
            Canera.sentivity *= 0;

        }
    }



    private void Stan()
    {
        TimeOfStan -= Time.deltaTime;
        if (TimeOfStan < 0)
        {
            pS.MoveSpeed += _First_MoveSpeed;
            _isStan = false;
            TimeOfStan += _First_TimeOfStan;
            Canera.sentivity += _First_SensivirtOfCamera;
        }
    }

   
}
