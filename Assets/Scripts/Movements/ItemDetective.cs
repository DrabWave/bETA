using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ItemDetective : MonoBehaviour
{
    public PlayerStats pS;

    RaycastHit hit;
    public GameObject Camera;
    public float distance;

    public string TagDetective;
    public GameObject currentObject;

    public int MaxCountDoors;
    public List<int> Keys = new List<int>();
    public Dictionary<int, bool> Door = new Dictionary<int, bool>();
    

    private void Start()
    {
        for (int i = 0; i < MaxCountDoors; i++) { Door[i] = false; }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E)) TagDetectiving();
        Activities();

    }

    private void TagDetectiving()
    {
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, distance))
        {
            Debug.Log(hit.collider.tag);
            TagDetective = hit.collider.tag;
            currentObject = hit.transform.gameObject;
        }
    }


    private void Activities()
    {
        switch (TagDetective)
        {
            case "Key":
                
                break;
            case "Key1":
                TakeKey(1);
                break;
            
            
            case "Door":                
                break;
            case "Door1":
                OpenDoor(1);
                break;
        }
    }


    private void TakeKey(int indexKey)
    {
        if (!Keys.Contains(indexKey))
        {
            Keys.Add(indexKey);
            Destroy(currentObject);
        }
    }

    private void OpenDoor(int indexDoor)
    {
        if(Door.ContainsKey(indexDoor))
        {
            if (Door[indexDoor])
            {
                Debug.Log("Дверь открыта");
            }
            else if (Keys.Contains(indexDoor))
            {
                Door[indexDoor] = true;
                Destroy(currentObject);
            }
            

        }


    }

    
    
}
        
    

