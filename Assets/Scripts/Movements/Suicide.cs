using UnityEngine;

public class Suicide : MonoBehaviour
{
    public float GameTime = 2400f;
    private PlayerStats ps; 
    void Start()
    {
        
    }

    void Update()
    {
        GameTime -= Time.deltaTime;

        if (GameTime < 0 ) 
        { 
            Debug.Log("Можно (нужно) самоубиться");
            GameTime = 0;
        }

    }
}
