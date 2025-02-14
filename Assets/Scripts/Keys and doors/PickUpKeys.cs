using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeys : MonoBehaviour
{
    [SerializeField]

    private TagDefinition e;
    private PlayerStats ps;
    public GameObject obj;

    void Start()
    {
        
    }

    void Update()
    {
        if (e.Name == "Key" && Input.GetKeyDown(KeyCode.E))
        {
            ps.keys.Add(true);
            Destroy(obj);

                

        }
    }
}
