using System;
using UnityEngine;

public class TriggerLeft : MonoBehaviour
{
    public PlayerStats pS;
    private bool _isZoneLeft = false;


    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player" && pS.Keys.Contains(1))
        {
            _isZoneLeft = true;
            Debug.Log("Heelo wrold!");
            // turn off all lights and will spawn emenies
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pS.Keys.Contains(1)) Destroy(gameObject);
    }
}
