using UnityEngine;
using UnityEngine.InputSystem;

public class Key1 : MonoBehaviour
{
    public bool Key1_InInventory = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //if (Input.GetKey(KeyCode.F))
            {
                Key1_InInventory = true;
                gameObject.SetActive(false);
            }
           

        }
    }







}
