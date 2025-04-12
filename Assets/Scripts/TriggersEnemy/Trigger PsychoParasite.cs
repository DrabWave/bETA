using UnityEngine;

public class TriggerPsychoParasite : MonoBehaviour
{
    public PsychicParasite paraste;
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
            paraste.Psychicparasite.enabled = true;
            Debug.Log("МОнстр появился");
            // turn off all lights and will spawn emenies
        }
    }
}
