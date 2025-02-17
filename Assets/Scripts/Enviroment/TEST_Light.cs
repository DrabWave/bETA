using UnityEngine;

public class TEST_Light : MonoBehaviour
{
    private Light lightComponent;
    private bool isOn = true;

    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    void Update()
    {
        if (Random.value > 0.98f) // 2% ���� �������� ���������
        {
            isOn = !isOn;
            lightComponent.enabled = isOn;
        }
    }
}
