using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public Sounds sos;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sos.PlaySound(sos.sounds[3]);
        }
    }
}
