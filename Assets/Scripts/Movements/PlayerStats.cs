using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Health;
    public float MoveSpeed;
    public string StatusOfVision = "��������� � �������";



    private void Update()
    {
        Debug.Log(Health);
        Debug.Log(MoveSpeed);
        Debug.Log(StatusOfVision);
    }
}
