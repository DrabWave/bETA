using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public PlayerStats pS;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pS.Health -= 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("вкееем!!!");
    }
}
