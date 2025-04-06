using UnityEngine;

public class creepingfog : MonoBehaviour
{
    public Enemies e;
    public PlayerStats ps;
    public PlayerController pl;
    public Vector3 targetPoint;
    public float moveSpeed;
    public Transform player;
    public float timeDeceleration;
    public float decelerationMoveSpeed;
    public float normalMoveSpeed;
    private void Start()
    {
        decelerationMoveSpeed = ps.MoveSpeed / 2;
        normalMoveSpeed = ps.MoveSpeed;
        timeDeceleration = 3f;
        moveSpeed = 2f;
        targetPoint = e.RandomPoint[Random.Range(0, e.RandomPoint.Length)].position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPoint) > 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint,moveSpeed * Time.deltaTime);
        }
        else
        {
            targetPoint = e.RandomPoint[Random.Range(0, e.RandomPoint.Length)].position;
        }


        if (Vector3.Distance(transform.position, player.position) <= 3f)
        {
            pl.canSprint = false;
            ps.MoveSpeed = decelerationMoveSpeed;
        }
        else
        {
            timeDeceleration -= Time.deltaTime;
            if (timeDeceleration <= 0)
            {
                ps.MoveSpeed = normalMoveSpeed;
                pl.canSprint = true;
            }
        }
    }

}
