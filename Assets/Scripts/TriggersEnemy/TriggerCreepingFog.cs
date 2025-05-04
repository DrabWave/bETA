using UnityEngine;

public class TriggerCreepingFog : MonoBehaviour
{
    public creepingfog creep;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            creep.CreepingFog.enabled = true;
            Debug.Log("Monster Was Spawn");
        }
    }
}
