using UnityEngine;

public class FuzzySilhouette : MonoBehaviour
{
    public TagDefinition tg;
    public Transform player;
    public float teleportDistance = 5f;
    public GameObject monster;
    public int rnd;
    public PlayerController pl;


    void Start()
    {
        
    }

    void Update()
    {
        if (IsPlayerLook())
        {
            Teleport();
        }
    }

    private bool IsPlayerLook()
    {

        if (tg.TagDetective == "FuzzySilhouette")
        {
            return true;
        }
        return false;

    }

    private void Teleport()
    {
        //Vector3 spawnPosition = player.position + (player.right /2) * teleportDistance;
        //spawnPosition.y = player.position.y;  
        //monster.transform.position = spawnPosition;
        rnd = Random.Range(0, 2);
        if (rnd == 0) transform.position += player.right * Time.deltaTime * teleportDistance; // появление справа
        if (rnd == 1) transform.position -= player.right * Time.deltaTime * teleportDistance; // появление слева




    }



}
