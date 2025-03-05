using UnityEngine;

public class FuzzySilhouette : MonoBehaviour
{
    public TagDefinition tg;
    public Transform player;
    public int rnd;
    public float teleportDistance = 5f;



    void Start()
    {
        
    }

    void Update()
    {
        if (tg.TagDetective == "FuzzySilhouette")
        {
            TeleportToRightOrLeft();
        }
        
    }


    private void TeleportToRightOrLeft()
    {
        //teleportDistance = Vector3.Distance(transform.position, player.position);
        rnd = Random.Range(0, 2);
        if (rnd == 0)
        {
            Vector3 newPos = player.position + transform.right * teleportDistance;
            transform.position = newPos;
        }
        else
        {
            Vector3 newPos = player.position - transform.right * teleportDistance;
            transform.position = newPos;
        }


    }
}
