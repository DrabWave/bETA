using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    


    public void ButtonRespawn()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void OpenFirstMenu()
    {
        SceneManager.LoadScene(0);
    }

}
