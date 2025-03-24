using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof(NavMeshAgent)) ]

public class PsychicParasite : MonoBehaviour
{
    // 2. Психические паразиты: Механика: Искажают интерфейс игрока: компас вращается, сообщения на экране заменяются угрозами.
    public Transform target;
    public float distance;
    NavMeshAgent myAgent;
    public CameraShake camShake;
    private bool isShaking = false;
    private float StartshakeDuration;
    public PlayerStats ps;
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        StartshakeDuration = camShake.shakeTime;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if (distance > 10)
        {
            myAgent.enabled = false;
            isShaking = false;
            camShake.shakeTime = StartshakeDuration;
        }

        if (distance <= 10 && distance > 3)
        {
            myAgent.enabled = true;
            myAgent.SetDestination(target.transform.position);
            isShaking = false;
            camShake.shakeTime = StartshakeDuration;
        }
        if (distance <= 3)
        {
            isShaking = true;
            if (isShaking)
            {
                camShake.shakeTime = 999999f;
                camShake.TriggerShake();
            }
            ps.Health -= 1 * Time.deltaTime;
            myAgent.enabled = false;
            Debug.Log("МОНСТР АТАКУЕТ");
            

        }





    }






}
