using UnityEngine;
using UnityEngine.AI;

public class creepingfog : MonoBehaviour
{
    public Enemies e;
    public PlayerStats ps;
    public PlayerController pl;
    private Vector3 targetPoint;
    public Transform player;
    public Transform[] targetPoints = new Transform[6];
    public float timeDeceleration;
    private float decelerationMoveSpeed;
    private float normalMoveSpeed;

    private float distanceToPlayer;
    private float distanceToTargetPoint;

    private bool isPlayerSlowed;

    public Renderer CreepingFog;

    NavMeshAgent myAgent;
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        decelerationMoveSpeed = ps.MoveSpeed - 2;
        normalMoveSpeed = ps.MoveSpeed;
        timeDeceleration = 5f;
        targetPoint = targetPoints[Random.Range(0, targetPoints.Length)].position;
        CreepingFog.enabled = false;
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        distanceToTargetPoint = Vector3.Distance(transform.position, targetPoint);

        if (CreepingFog.enabled == false) myAgent.enabled = false;
        else myAgent.enabled = true;


        if (myAgent.enabled == true)
        {
            if (distanceToTargetPoint > 3)
            {
                myAgent.SetDestination(targetPoint);
            }
            else
            {
                targetPoint = targetPoints[Random.Range(0, targetPoints.Length)].position;
            }


            if (distanceToPlayer <= 3)
            {
                ApplyDeceleration();
                timeDeceleration = 5f;
            }
            else if (isPlayerSlowed)
            {

                timeDeceleration -= Time.deltaTime;

                if (timeDeceleration <= 0)
                {
                    RemoveDeceleration();
                }
            }
        }
        
        
    }

    private void ApplyDeceleration()
    {
        if (!isPlayerSlowed)
        {
            ps.MoveSpeed = decelerationMoveSpeed;
            pl.canSprint = false;
            isPlayerSlowed = true;
        }
    }

    private void RemoveDeceleration()
    {
        ps.MoveSpeed = normalMoveSpeed;
        pl.canSprint = true;
        isPlayerSlowed = false;
    }
}
