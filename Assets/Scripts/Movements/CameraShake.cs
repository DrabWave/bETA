using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeTime = 0.5f; //время тряски
    public float shakePower = 0.1f;//сила тряски
    public PlayerStats ps;
    private Vector3 originalPosition;
    private Camera cameraComponent;
    void Start()
    {
        originalPosition = transform.localPosition;
        cameraComponent = GetComponent<Camera>();
    }

    void Update()
    {
        
    }

    public void TriggerShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {

        float elapsed = 0.0f;
        while (elapsed < shakeTime)
        {
            ps.StatusOfVision = "Тряска камеры";
            float x = Random.Range(-1f, 1f) * shakePower;
            float y = Random.Range(-1f, 1f) * shakePower;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;


        }
        transform.localPosition = originalPosition;
        ps.StatusOfVision = "Видимость в порядке";
    }




}
