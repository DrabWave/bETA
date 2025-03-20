using UnityEngine;

public class FlashLight : MonoBehaviour
{

    // бл€ть рандом заху€чить, чтобы мерцани€ были, а также батарейки

    private Light flashLight;
    private bool isOn = false;


    private float TotalTime = 300f;
    private float currentTime;



    private void Start()
    {
        flashLight = GetComponent<Light>();
        flashLight.enabled = false;
        currentTime = TotalTime;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) { isOn = !isOn; flashLight.enabled = isOn; }
    }



    private void Time()
    {
        while (currentTime > 0)
        {

        }
    }

}