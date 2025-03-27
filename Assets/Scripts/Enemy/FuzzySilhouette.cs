using Unity.VisualScripting;
using UnityEngine;

public class FuzzySilhouette : MonoBehaviour
{
    public TagDefinition tg;
    public Transform player;
    public float disappearDistance = 20f; // ���������, ��� ������� ������ ��������
    public Vector3 spawnOffset = new Vector3(5f, 0f, 0f); // �������� ��� ��������� �����
    private Renderer monsterRenderer; // �������� �������
    private bool isVisible = true; // ������� ��������� ���������
    public float distanceToPlayer;

    void Start()
    {
        monsterRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < disappearDistance && tg.TagDetective == "FuzzySilhouette")
        {
            Disappear();
        }
        else if (!isVisible)
        {
            Spawn();
        }
    }

    private void Disappear()
    {
        monsterRenderer.enabled = false;
        isVisible = false;
    }

    private void Spawn()
    {
        monsterRenderer.enabled = true;
        isVisible = true;
    }


    /*private void Teleport()
    {
        //Vector3 spawnPosition = player.position + (player.right /2) * teleportDistance;
        //spawnPosition.y = player.position.y;  
        //monster.transform.position = spawnPosition;
        rnd = Random.Range(0, 2);
        if (rnd == 0) transform.position = transform.position + player.right * teleportDistance; // ��������� ������
        if (rnd == 1) transform.position = transform.position - player.right * teleportDistance; // ��������� �����




    }
    */


}
