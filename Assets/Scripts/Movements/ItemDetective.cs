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

    private int MaxCountDoors = 3;

    public GameObject[] keys = new GameObject[] { };

    private void Start()
    {
        for (int i = 0; i < MaxCountDoors; i++)
        {
            pS.Door[i] = false;
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.E)) { TagDetectiving(); Activities(); }
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
                OpenDoor(1, 4);

                break;
        }
    }


    private void TakeKey(int indexKey)
    {
        if (currentObject != null)
        {
            pS.Keys.Add(indexKey);
            Destroy(currentObject);
        }
    }



    private void OpenDoor(int indexDoor, int LastCountDoor)
    {
        if(pS.Door.ContainsKey(indexDoor))
        {
            if (pS.Door[indexDoor])
            {
                Debug.Log("YES");
            }
            else if (pS.Keys.Contains(indexDoor) && pS.Keys[LastCountDoor] == indexDoor)
            {
                pS.Door[indexDoor] = true;
                Destroy(currentObject);
            }          
        }
    }






}
        
    

