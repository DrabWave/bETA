using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light flashLight;
    private bool isOn = false;


    private void Start()
    {
        flashLight = GetComponent<Light>();
        flashLight.enabled = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) { isOn = !isOn; flashLight.enabled = isOn; }
    }
}
