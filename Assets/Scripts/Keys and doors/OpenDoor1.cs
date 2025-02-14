using UnityEngine;
using UnityEngine.UIElements;

public class OpenDoor1 : MonoBehaviour
{
    private TagDefinition e;
    private PlayerStats key;
    public GameObject obj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (e.Name == "Door1" && key.keys[0] == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(obj);
        }

    }
}
