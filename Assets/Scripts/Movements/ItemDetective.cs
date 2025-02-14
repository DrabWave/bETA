using UnityEngine;

public class ItemDetective : MonoBehaviour
{
    RaycastHit hit;
    public GameObject Camera;
    public float distance;

    public string TagDetective;


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E)) TagDetectiving();
        Activities();
    }

    private void TagDetectiving()
    {
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, distance))
        {
            Debug.Log(hit.collider.tag);
            TagDetective = hit.collider.tag;
        }
    }


    private void Activities()
    {
        switch (TagDetective)
        {
        }
    }

}
