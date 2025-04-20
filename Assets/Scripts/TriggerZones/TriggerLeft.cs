using System;
using UnityEngine;

public class TriggerLeft : MonoBehaviour
{
    public PlayerStats pS;
    private bool _isZoneLeft = false;
    public PsychicParasite paraste;


    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player" && pS.Keys.Contains(1))
        {
            _isZoneLeft = true;
            paraste.Psychicparasite.enabled = true;
            Debug.Log("МОнстр появился");
            // turn off all lights and will spawn emenies
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pS.Keys.Contains(1)) Destroy(gameObject);
    }
}
