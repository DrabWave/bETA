using UnityEngine;

public class FlashLight : MonoBehaviour
{

    // бл€ть рандом заху€чить, чтобы мерцани€ были, а также батарейки
    public PlayerStats pS;

    public Light flashLight;
    public bool isOn = false;


    float _totalTime = 300f;
    private float _currentTime;

    private void Start()
    {
        flashLight = GetComponent<Light>();
        flashLight.enabled = false;
        _currentTime = _totalTime;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && pS.Batteries > 0) 
        { 
            isOn = !isOn; 
            flashLight.enabled = isOn;
        }
    }



    

}