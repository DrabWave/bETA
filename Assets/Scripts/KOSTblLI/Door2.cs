using UnityEngine;

public class Door2 : MonoBehaviour
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
