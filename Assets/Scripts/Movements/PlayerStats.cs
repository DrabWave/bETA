using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public HUD HUD;
    
    public float MindLevel;
    
    public float Batteries;



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
        SceneManager.LoadScene(2);
        Cursor.visible = true;
        Player.transform.position = respawnPoint.transform.position;
        Health = 3f;
        HUD.img_LevelBattary.fillAmount = 0;
    }
}
