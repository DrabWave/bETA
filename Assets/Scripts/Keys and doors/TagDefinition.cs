using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;

public class TagDefinition : MonoBehaviour
{
    public GameObject currentObject;
    public string TagDetective;
    public int MaxCountDoors;
    public List<int> keys = new List<int>();
    public Dictionary<int, bool> Door = new Dictionary<int, bool>();

    void Start()
    {
        for (int i = 0; i < MaxCountDoors; i++) { Door[i] = false; }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) TagDetectiving();
        interaction();
    }

    private void TagDetectiving()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.tag);
            TagDetective = hit.collider.tag;
            currentObject = hit.transform.gameObject;


        } 
    }
    private void OpenDoor(int indexDoor)
    {
        if (Door.ContainsKey(indexDoor))
        {
            if (Door[indexDoor])
            {
                Debug.Log("PORNO");
            }
            else if (keys.Contains(indexDoor))
            {
                Door[indexDoor] = true;
                Destroy(currentObject);
            }
        }
    }

    private void TakeKey(int indexKey)
    {
        if (!keys.Contains(indexKey))
        {
            keys.Add(indexKey);
            Destroy(currentObject);
        }
    }
   

    private void interaction()
    {
        switch (TagDetective)
        {
            case "Key1":
                TakeKey(1);
                break;

            case "Key2":
                TakeKey(2);
                break;

            case "Door1":
                OpenDoor(1);
                break;

            case "Door2":
                OpenDoor(2);
                break;


        }
    }
}
