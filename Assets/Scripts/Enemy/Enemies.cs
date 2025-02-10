using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.Rendering;

public class Enemies : MonoBehaviour
{
    
    public Transform[] RandomPoint = new Transform[10];


    void Start()
    {
        
    }


    void Update()
    {
        
    }




    public void TeleportEnemy(Transform nowTransform)
    {
        nowTransform.transform.position = RandomPoint[Random.Range(0, RandomPoint.Length)].position;
    }
}
