using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{


    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
}
