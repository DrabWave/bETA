using UnityEngine;

public class TakeObject : MonoBehaviour
{
    RaycastHit hit;


    public Transform pointHand;
    public GameObject Camera;
    public float distance;
    public bool canPickUp;



    private GameObject _currentObject;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }



    public void PickUp()
    {
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "---")
            {
                if (canPickUp) Drop();


                _currentObject = hit.transform.gameObject;
                _currentObject.GetComponent<Rigidbody>().isKinematic = true;
                _currentObject.GetComponent<Collider>().isTrigger = true;
                _currentObject.transform.parent = transform;
                _currentObject.transform.localPosition = new Vector3(pointHand.transform.position.x, pointHand.transform.position.y, pointHand.transform.position.z);
                _currentObject.transform.localEulerAngles = new Vector3(10f, -100f, 0f);

                canPickUp = true;
            }
        }
    }

    public void Drop()
    {
        _currentObject.transform.parent = null;
        _currentObject.GetComponent<Rigidbody>().isKinematic = false;
        _currentObject.GetComponent<Collider>().isTrigger = false;

        canPickUp = false;
        _currentObject = null;
    }
}
