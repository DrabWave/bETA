using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;

public class TagDefinition : MonoBehaviour
{
    public string Name;

    void Start()
    {
        
    }

   
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Name = hit.collider.tag;

        }

        Debug.DrawRay(transform.position, transform.forward * 2f, Color.red);
    }

}
