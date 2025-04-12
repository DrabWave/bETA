using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    // *new ��������. ��������: ���� ���������� �� ���������� � �������. ������ ���� ������� ������� ���������, ����� ��� �������� ���������� � �����.
    // 
    public float MindLevel;

    private Transform Player;
    public Transform respawnPoint;

    public float Health;
    public float MoveSpeed;
    public string StatusOfVision = "��������� � �������";
    public string StatusOfInterface = "��������� � �������";

    public List<int> Keys = new List<int>();
    public Dictionary<int, bool> Door = new Dictionary<int, bool>();

    public List<int> KeyCards = new List<int>();
    public Dictionary<int, bool> DoorCards = new Dictionary<int, bool>(); 

    private void Start()
    {
        Player = transform;
    }

    private void Update()
    {
        
        //Debug.Log(Health);
        //Debug.Log(MoveSpeed);
        //Debug.Log(StatusOfVision);
        //Debug.Log(StatusOfInterface);

        if (Health <= 0) Dead();
    }


    private void Dead()
    {
        // DeadScreen.UI.isEnable = true;
        Player.transform.position = respawnPoint.transform.position;
        Health = 3f;
    }
}
