using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SilentStalker : MonoBehaviour
{
    public Sounds sos;

    public Transform player;
    public TagDefinition tg;
    public float followDistance = 5f; //расстояние преследование до игрока
    public float speed = 8f; //скорость монстра
    public Camera playerCamera;
    public Renderer stalker;

    public float time;

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


            if (time <= 0)
            {
                time = sos.sounds[4].length;
            }
            if (time == sos.sounds[4].length)
            {
                sos.PlaySound(sos.sounds[4],70f);
            }
        }

        


    }

    private void FixedUpdate()
    {
        if (stalker.enabled == true)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = -1;
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
