using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using System.Runtime.ConstrainedExecution;

public class TagDefinition : MonoBehaviour
{
    public PlayerStats pS;
    public HUD HUD;

    public GameObject currentObject;
    public KeysAndDoors KD;
    public Transform player;
    public string TagDetective;
    // Общая дистанция для возможности подбирания ключей и открывания дверей ( и не только) будет равна 5, в будщем можно изменить
    public float distance;
    public bool canTake;

    RaycastHit hit;
    Ray ray;



    void Start()
    {

    }


    void Update()
    {
        TagDetectiving();
        if (Input.GetKeyDown(KeyCode.E)) interaction();

    }

    public void TagDetectiving()
    {
        ray = new Ray(transform.position, transform.forward);

        
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
    public void interaction()
    {


        switch (TagDetective, canTake)
        {

            case ("Battery", true):
                pS.Batteries++;
                HUD.img_LevelBattary.fillAmount = 1;
                break;

            case ("RespawnDevice", true):
                pS.respawnPoint.position = player.position;
                Debug.Log("Установлена новая точка сохранеия!");
                break;

            case ("KeyCard1", true):
                KD.TakeKeyCard(1);
                break;

            case ("DoorCard1", true):
                KD.OpenDoorCard(1);
                break;

            case ("KeyCard2", true):
                KD.TakeKeyCard(2);
                break;

            case ("DoorCard2", true):
                KD.OpenDoorCard(2);
                break;


            case ("Key1", true):
                KD.TakeKey(1);
                break;

            case ("Key2", true):
                KD.TakeKey(2);
                break;

            case ("Door1", true):
                KD.OpenDoor(1);
                break;





        }
    }
}
