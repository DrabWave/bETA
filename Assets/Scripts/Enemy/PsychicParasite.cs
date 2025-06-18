using System.Collections;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof(NavMeshAgent)) ]

public class PsychicParasite : MonoBehaviour
{
    // 2. Психические паразиты: Механика: Искажают интерфейс игрока: компас вращается, сообщения на экране заменяются угрозами.
    public Transform target;
    public Enemies e;
    public float distance;
    public Vector3 targetPoint;
    public Transform[] targetPoints = new Transform[10];
    NavMeshAgent myAgent;
    public CameraShake camShake;
    private bool isShaking = false;
    private float StartshakeDuration;
    public PlayerStats ps;
    public PlayerController pl;
    public Renderer Psychicparasite;
    public bool playerOnPlane;
    public bool attacking;
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        StartshakeDuration = camShake.shakeTime;
        Psychicparasite = GetComponent<Renderer>();
        targetPoint = targetPoints[Random.Range(0,targetPoints.Length)].position;
        Psychicparasite.enabled = false;
    }

    private void Update()
    {
        playerOnPlane = PlayerOnPlane(target.position);
        distance = Vector3.Distance(transform.position, target.position);

        if (Psychicparasite.enabled == false) myAgent.enabled = false;
        else myAgent.enabled = true;


        if (pl.isCrowing == false)
        {
            if (distance > 20 || !playerOnPlane)
            {
                myAgent.enabled = true;
                isShaking = false;
                camShake.shakeTime = StartshakeDuration;

                if (Vector3.Distance(transform.position, targetPoint) > 3)
                {
                    myAgent.SetDestination(targetPoint);
                }
                else
                {
                    targetPoint = targetPoints[Random.Range(0,targetPoints.Length)].position;
                }
                
            }


            if (distance <= 20 && distance > 3 && playerOnPlane)
            {
                myAgent.enabled = true;
                myAgent.SetDestination(target.transform.position);
                isShaking = false;
                camShake.shakeTime = StartshakeDuration;
            }

            if (distance <= 3 && playerOnPlane)
            {
                isShaking = true;
                if (isShaking)
                {
                    camShake.shakeTime = 999999f;
                    camShake.TriggerShake();
                }
                if (!attacking) StartCoroutine(Attack());
                myAgent.enabled = false;
                Debug.Log("МОНСТР АТАКУЕТ");


            }
        }
        else if (pl.isCrowing == true)
        {
            if (distance > 15 || !playerOnPlane)
            {
                myAgent.enabled = true;
                isShaking = false;
                camShake.shakeTime = StartshakeDuration;

                if (Vector3.Distance(transform.position, targetPoint) > 3)
                {
                    myAgent.SetDestination(targetPoint);
                }
                else
                {
                    targetPoint = targetPoints[Random.Range(0, targetPoints.Length)].position;
                }

            }


            if (distance <= 15 && distance > 3 && playerOnPlane)
            {
                myAgent.enabled = true;
                myAgent.SetDestination(target.transform.position);
                isShaking = false;
                camShake.shakeTime = StartshakeDuration;
            }

            if (distance <= 3 && playerOnPlane)
            {
                isShaking = true;
                if (isShaking)
                {
                    camShake.shakeTime = 999999f;
                    camShake.TriggerShake();
                }
                if (!attacking) StartCoroutine(Attack());
                myAgent.enabled = false;
                Debug.Log("МОНСТР АТАКУЕТ");


            }
        }



    }


    private bool PlayerOnPlane(Vector3 playerPosition)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(playerPosition, out hit, 2.0f, NavMesh.AllAreas);
    }

    private IEnumerator Attack()
    {
        attacking = true;
        e.Damage(1);
        yield return new WaitForSeconds(2f);
        attacking = false;
    }





}
