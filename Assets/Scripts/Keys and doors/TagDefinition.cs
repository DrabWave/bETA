using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;
using System.Runtime.ConstrainedExecution;

public class TagDefinition : Sounds
{
    public PlayerStats pS;
    public HUD HUD;
    public Door[] Door;
    public Door1[] Door1;
    public Door2[] Door2;
    public Door3[] Door3;
    public Door4[] Door4;
    public Door5[] Door5;



    public GameObject currentObject;
    public KeysAndDoors KD;
    public Transform player;
    public string TagDetective;
    // Общая дистанция для возможности подбирания ключей и открывания дверей ( и не только) будет равна 5, в будщем можно изменить
    public float distance;
    public bool canTake;

    private Animator anim;

    RaycastHit hit;
    Ray ray;
    



    void Start()
    {
        anim = GetComponent<Animator>();
        
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

            // Enviroment
            case ("Battery", true):
                pS.Batteries++;
                HUD.img_LevelBattary.fillAmount = 1;
                Destroy(currentObject);
                break;

            case ("RespawnDevice", true):
                pS.respawnPoint.position = player.position;
                Debug.Log("Установлена новая точка сохранеия!");
                break;

            

            // KEY
            case ("Key1", true):
                KD.TakeKey(1);
                break;

            case ("Key2", true):
                KD.TakeKey(2);
                break;

            case ("Key3", true):
                KD.TakeKey(3);
                break;

            case ("Key4", true):
                KD.TakeKey(4);
                break;

            case ("Key5", true):
                KD.TakeKey(5);
                break;


            // DOOR
            case ("Door", true):
                Door[0].OpenDoor(true);
                Door[1].OpenDoor(true);
                
                PlaySound(sounds[1]);
                break;

            case ("Door1", true):
                KD.OpenDoor(1);
                if (KD.toOpen[1] == true) {
                    Door1[0].OpenDoor(true);
                    Door1[1].OpenDoor(true);

                    PlaySound(sounds[1]);
                }
                break;

            case ("Door2", true):
                KD.OpenDoor(2);

                if (KD.toOpen[2] == true)
                {
                    Door2[0].OpenDoor(true);
                    Door2[1].OpenDoor(true);

                    PlaySound(sounds[1]);
                }
                break;

            case ("Door3", true):
                KD.OpenDoor(3);

                if (KD.toOpen[3] == true)
                {
                    Door3[0].OpenDoor(true);
                    Door3[1].OpenDoor(true);

                    PlaySound(sounds[1]);
                }
                break;

            case ("Door4", true):
                KD.OpenDoor(4);

                if (KD.toOpen[4] == true)
                {
                    Door4[0].OpenDoor(true);
                    Door4[1].OpenDoor(true);

                    PlaySound(sounds[1]);
                }
                break;

            case ("Door5", true):
                KD.OpenDoor(5);

                if (KD.toOpen[5] == true)
                {
                    Door5[0].OpenDoor(true);
                    Door5[1].OpenDoor(true);

                    PlaySound(sounds[1]);
                }
                break;

        }
    }
}
