using UnityEngine;

public class RandomLight : MonoBehaviour
{
    private Light lightComponent => GetComponent<Light>();
    private bool isOn = true;

    void Update()
    {
        if (Random.value > 0.985f) 
        {
            isOn = !isOn;
            lightComponent.enabled = isOn;
        }
    }
}
