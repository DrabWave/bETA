using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class TagDefinition : MonoBehaviour
{
    public PlayerStats pS;
    public GameObject currentObject;
    public KeysAndDoors KD;
    public string TagDetective;
    // Общая дистанция для возможности подбирания ключей и открывания дверей ( и не только) будет равна 5, в будщем можно изменить
    public float distance;
    public bool canTake;
     
    

    void Start()
    {
        
    }


    void Update()
    {
        TagDetectiving();
        if (Input.GetKeyDown(KeyCode.E)) KD.interaction();

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
}
