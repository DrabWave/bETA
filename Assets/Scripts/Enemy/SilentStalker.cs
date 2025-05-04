using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SilentStalker : MonoBehaviour
{

    public Transform player;
    public TagDefinition tg;
    public float followDistance = 5f; //расстояние преследование до игрока
    public float speed = 8f; //скорость монстра
    public Camera playerCamera;
    public Renderer stalker;

    private void Start()
    {
        stalker.enabled = false;
    }
    private void Update()
    {
        if (stalker.enabled == true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > followDistance) FollowPlayer();
            if (tg.TagDetective == "SilentStalker") TeleportBehindPlayer();
        }
        
    }

    private void TeleportBehindPlayer()
    {
        Vector3 behindPlayerPosition = player.position - player.forward * followDistance;
        behindPlayerPosition.y = player.position.y;
        transform.position = behindPlayerPosition;
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = player.position - player.forward * followDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

    }





}
