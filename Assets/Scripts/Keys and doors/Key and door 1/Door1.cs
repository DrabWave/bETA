using UnityEngine;

public class Door1 : MonoBehaviour
{
    public Key1 key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && key.Key1_InInventory == true)
        {
            
            //if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
            }
            
        }
    }


}
