using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.Rendering;

public class Enemies : MonoBehaviour
{
    public Transform Player;
    public Transform[] RandomPoint = new Transform[10];


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void GoingToPlayer(Transform nowTransform, float step)
    {
        nowTransform.transform.position = Vector3.MoveTowards(nowTransform.position, Player.position, step);
    }


    public void TeleportEnemy(Transform nowTransform)
    {
        nowTransform.transform.position = RandomPoint[Random.Range(0, RandomPoint.Length)].position;
    }
}
