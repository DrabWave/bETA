using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Health;
    public float MoveSpeed;



    private void Update()
    {
        Debug.Log(Health);
        Debug.Log(MoveSpeed);
    }
}
