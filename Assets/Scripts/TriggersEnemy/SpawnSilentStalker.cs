using UnityEngine;

public class TriggerSilentStalker : MonoBehaviour
{
    public SilentStalker stalk;
    public Transform player;
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
            stalk.stalker.enabled = true;
            stalk.transform.position = player.position - player.forward * stalk.followDistance;
            Debug.Log("Monstr ZA SPINOY");
        }
    }


}
