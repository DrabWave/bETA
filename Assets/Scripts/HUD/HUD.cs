using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerStats pS;
    public FlashLight FL;


    public Image img_LevelBattary;
    public float TimeWorkingBattery;




    private void Update()
    {
        

        if (FL.isOn == true)
        {
            img_LevelBattary.fillAmount -= TimeWorkingBattery * Time.deltaTime;
        }
        if (img_LevelBattary.fillAmount == 0)
        {
            pS.Batteries = 0;
            FL.isOn = false;
            FL.flashLight.enabled = false;
        }
    }

}
