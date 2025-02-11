using UnityEngine;

public class Suicide : MonoBehaviour
{
    public float GameTime;
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
