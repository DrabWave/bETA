using UnityEngine;

public class PsychicParasite : MonoBehaviour
{
    // 2. ����������� ��������: ��������: �������� ��������� ������: ������ ���������, ��������� �� ������ ���������� ��������.
    public Enemies e;
    public bool Distortion;
    public float TimeOfDistortion;
    public PlayerStats ps;
    public GameObject obj;
    private float FirstTimeOfDistortion;
    private string FirstStatusInterface;



    void Start()
    {
        FirstTimeOfDistortion = TimeOfDistortion;
        Distortion = false;
        FirstStatusInterface = ps.StatusOfInterface;
    }

    // Update is called once per frame
    void Update()
    {
        if (Distortion) Distorition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Distortion = true;
            ps.StatusOfInterface = "�������� ������ ���������";
        }
    }

    private void Distorition()
    {
        TimeOfDistortion -= Time.deltaTime;
        if (TimeOfDistortion < 0)
        {
            Distortion = false;
            TimeOfDistortion = FirstTimeOfDistortion;
            ps.StatusOfInterface = FirstStatusInterface;
            Destroy(obj);

        }
    }





}
