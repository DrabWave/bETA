using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapePanel : MonoBehaviour
{
    public Camera Camera;

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
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            PanelEscapeMenu.SetActive(true); 
            
            Cursor.visible = true; 
            Camera.StopSentivity(true); 
        }
        
    }
    public void CloseEscapeMenu()
    {
        PanelEscapeMenu.SetActive(false);
        
        Cursor.visible = false;
        Camera.StopSentivity(false);
    }
    public void OpenFirstMenu()
    {
        SceneManager.LoadScene(0);
    }
}
