using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Door : MonoBehaviour
{


    private Animator anim;
    


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor(bool toOpen)
    {
        anim.enabled = toOpen;
        
    }
}
