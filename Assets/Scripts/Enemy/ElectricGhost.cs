using UnityEngine;

public class ElectricGhost : MonoBehaviour
{
    // Ёлектрический призрак: Ќевидимый монстр, который создаЄт электрические разр€ды, временно парализу€ игрока.

    public Enemies E;
    public PlayerStats pS;

    public float TimeOfStan;

    private Transform _positionElectricGhost;
    private bool _isStan;


    private void Start()
    {
        _positionElectricGhost = transform;
        _isStan = false;
    }

    private void Update()
    {

        if( _isStan == true)
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

        }
    }



    private void Stan()
    {
        TimeOfStan -= Time.deltaTime;
        if (TimeOfStan < 0)
        {
            pS.MoveSpeed += 6;
            _isStan = false;
            TimeOfStan += 5;
        }
    }

   
}
