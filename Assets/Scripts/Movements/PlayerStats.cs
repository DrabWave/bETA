using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public float Health;
    public float MoveSpeed;
    public string StatusOfVision = "Видимость в порядке";

    


    private void Update()
    {
        Debug.Log(Health);
        Debug.Log(MoveSpeed);
        Debug.Log(StatusOfVision);


        if (Health <= 0) Dead();
    }


    private void Dead()
    {
        Debug.Log("Character was dead!");
    }
}
