using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class TagDefinition : MonoBehaviour
{
    public PlayerStats pS;
    public GameObject currentObject;
    public string TagDetective;
    public int MaxCountDoors;
    // Общая дистанция для возможности подбирания ключей и открывания дверей ( и не только) будет равна 5, в будщем можно изменить
    public float distance;
    public bool canTake;
     
    

    void Start()
    {
        for (int i = 0; i < MaxCountDoors; i++) { pS.Door[i] = false; }
        for (int i = 0; i < MaxCountDoors; i++) { pS.DoorCards[i] = false; }
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
            distance = Vector3.Distance(transform.position, currentObject.transform.position);
            if (distance <= 5f)
            {
                canTake = true;
            }
            else
            {
                canTake = false;
            }
        } 
    }
    private void OpenDoor(int indexDoor)
    {
        if (pS.Door.ContainsKey(indexDoor))
        {
            if (pS.Door[indexDoor])
            {
                Debug.Log("PORNO");
            }
            else if (pS.Keys.Contains(indexDoor))
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

    private void TakeKeyCard(int indexKeyCard)
    {
        if (currentObject != null)
        {
            pS.KeyCards.Add(indexKeyCard);
            Destroy(currentObject);
        }
    }

    private void OpenDoorCard(int indexDoorCard)
    {
        int countCards = 0;
        foreach (var i in pS.KeyCards)
        {
            if (i == indexDoorCard)
            {
                countCards++;
            }
        }
        if (pS.DoorCards.ContainsKey(indexDoorCard))
        {
            if (pS.DoorCards[indexDoorCard])
            {
                Debug.Log("PORNO");
            }
            else if (pS.KeyCards.Contains(indexDoorCard) && countCards == 5)
            {
                pS.DoorCards[indexDoorCard] = true;
                Destroy(currentObject);
            }
        }
    }


   

    private void interaction()
    {


        switch (TagDetective,canTake)
        {
            //case "RespawnDevice":

            //    break;

            //case "AudioNote":
            //    break;

            //case "Note":
            //    break;

            //case "Battery":
            //    break;

            case ("KeyCard1", true):
                TakeKeyCard(1);
                break;

            case ("DoorCard1", true):
                OpenDoorCard(1);
                break;

            case ("KeyCard2", true):
                TakeKeyCard(2);
                break;

            case ("DoorCard2", true):
                OpenDoorCard(2);
                break;


            case ("Key1", true):
                TakeKey(1);
                break;

            case ("Key2", true):
                TakeKey(2);
                break;

            case ("Door1", true):
                OpenDoor(1);
                break;
           


                
            


        }



    }
}
