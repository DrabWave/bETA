using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SilentStalker : MonoBehaviour
{
    public TagDefinition tg;
    public Transform player;
    public float distance = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tg.TagDetective == "SilentStalker")
        {
            Tleport();
        }
    }
    private void Tleport()
    {
        Vector3 teleportPos = player.position - player.forward * distance;
        teleportPos.y = player.position.y;


        transform.position = teleportPos;
    }
}
