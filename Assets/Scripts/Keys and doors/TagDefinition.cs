using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;

public class TagDefinition : MonoBehaviour
{
    public PlayerStats pS;


    public GameObject currentObject;
    public string TagDetective;
    public int MaxCountDoors;
    

    void Start()
    {
        for (int i = 0; i < MaxCountDoors; i++) { pS.Door[i] = false; }
    }


    void Update()
    {
        TagDetectiving();
        if (Input.GetKeyDown(KeyCode.E)) interaction();

    }

    public void TagDetectiving()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.tag);
            TagDetective = hit.collider.tag;
            currentObject = hit.transform.gameObject;


        } 
    }
    private void OpenDoor(int indexDoor, int LastCountDoor)
    {
        if (pS.Door.ContainsKey(indexDoor))
        {
            if (pS.Door[indexDoor])
            {
                Debug.Log("PORNO");
            }
            else if (pS.Keys.Contains(indexDoor) && pS.Keys[LastCountDoor] == indexDoor)
            {
                pS.Door[indexDoor] = true;
                Destroy(currentObject);
            }
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
   

    private void interaction()
    {
        /*
         * Door Keys
         * 1    4 
         * 2    9
         * 3    14
         * _____________
         * i++  i+= 5
         */


        switch (TagDetective)
        {
            case "Key1":
                TakeKey(1);
                break;

            case "Key2":
                TakeKey(2);
                break;

            case "Door1":
                OpenDoor(1, 4);
                break;
            
            case "Door2":
                OpenDoor(2, 9);
                break;



        }
    }
}
