using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapePanel : MonoBehaviour
{
    private Camera Camera;

    public GameObject PanelEscapeMenu;
    
    void Start()
    {
        PanelEscapeMenu.SetActive(false);
    }

    
    void Update()
    {
        OpenEscapeMenu();
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void OpenEscapeMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { PanelEscapeMenu.SetActive(true); Cursor.visible = true; }
        
    }
    public void CloseEscapeMenu()
    {
        PanelEscapeMenu.SetActive(false);
        Cursor.visible = false;
    }
    public void OpenFirstMenu()
    {
        SceneManager.LoadScene(0);
    }
}
