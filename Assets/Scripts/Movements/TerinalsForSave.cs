using UnityEngine;

public class TerinalsForSave : MonoBehaviour
{
    public Transform[] SpawnPoints = new Transform[4];
    public TagDefinition tg;
    public PlayerStats ps;



    
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void ActivateTerminals(int numberTerminal)
    {
        ps.respawnPoint = SpawnPoints[numberTerminal - 1];
        Debug.Log("ÒÎ×ÊÀ ÑÏÀÂÍÀ ÓÑÒÀÍÎÂËÅÍÀ");
    }






}
