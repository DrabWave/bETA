using System.Collections;
using UnityEngine;

public class ElectricGhost : MonoBehaviour
{
    // Электрический призрак: Невидимый монстр, который создаёт электрические разряды, временно парализуя игрока.
    // задача: тряска камеры при стане

    public Enemies E;
    public PlayerStats pS;
    public Camera Canera;
    public float distanceForAttack;
    public Transform player;
    public float distance;
    public float TimeOfStan;
    private Transform _positionElectricGhost;
    public bool _isStan;
    private float _First_TimeOfStan;
    private float _First_MoveSpeed;
    private float _First_SensivirtOfCamera;


    private void Start()
    {
        _positionElectricGhost = transform;
        _isStan = false;
        distanceForAttack = 10f;
        _First_MoveSpeed = pS.MoveSpeed;
        _First_TimeOfStan = TimeOfStan;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        //if (distance < distanceForAttack)
        //{
        //    //Выключение света
        //}

        if (distance < 5f)
        {
            //StartCoroutine(ScreenGlitch(Canera));
            Stan();
        }

        
    }


    //IEnumerator ScreenGlitch(Camera camera)
    //{
    //    for (int i = 0; i < 15; i++)
    //    {
    //        camera.backgroundColor = Color.red;
    //        yield return new WaitForSeconds(0.05f);
    //        camera.backgroundColor = Color.black;
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //    camera.backgroundColor = Color.black;
    //}

    





    private void Stan()
    {
        _isStan = true;
        pS.MoveSpeed = 0;
        TimeOfStan -= Time.deltaTime;
        if (TimeOfStan < 0)
        {
            E.TeleportEnemy(_positionElectricGhost);
            pS.MoveSpeed += _First_MoveSpeed;
            _isStan = false;
            TimeOfStan += _First_TimeOfStan;
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        E.TeleportEnemy(_positionElectricGhost);
    //        _isStan = true;

    //        pS.MoveSpeed *= 0;
    //        Canera.sentivity *= 0;

    //    }
    //}


}
