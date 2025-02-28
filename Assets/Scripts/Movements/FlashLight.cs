using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light _flash;
    private bool isOn = false;

    private float totalTime = 300f;
    private float currentTime;
    private bool isTimeRunnin = false;


    private void Start()
    {
        _flash = GetComponent<Light>();
        _flash.enabled = false;

        currentTime = totalTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            _flash.enabled = isOn;

           
        }

    }

    private IEnumerator TimeCorotine()
    {
        isTimeRunnin = true;

        while(currentTime > 0)
        {
            currentTime -= Time.deltaTime;


            yield return null;
        }

        isTimeRunnin = false;
    }
}
