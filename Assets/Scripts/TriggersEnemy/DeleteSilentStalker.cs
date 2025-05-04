using UnityEngine;

public class DeleteSilentStalker : MonoBehaviour
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
            stalk.stalker.enabled = false;
            Debug.Log("Monstr MERTV");
        }
    }
}
