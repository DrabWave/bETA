using UnityEngine;

public class creepingfog : MonoBehaviour
{
    // ���������� �����: ������ ����������, ������� ���������� �������� � ���������.

    public Enemies e;
    public PlayerStats ps;

   
    public float DecelerationTime;  // ����� ����������
    private Transform _positionCreepingfog;
    private bool _deceleration;
    private float _FirstTimeDeceleration;
    private float _FirstMS;
    private string _FirsStatusOfVision;

    public float Step;

    void Start()
    {
        _positionCreepingfog = transform;
        _deceleration = false;
        _FirstMS = ps.MoveSpeed;
        _FirstTimeDeceleration = DecelerationTime;
        _FirsStatusOfVision = ps.StatusOfVision;

    }

    // Update is called once per frame
    void Update()
    {
       // e.GoingToPlayer(_positionCreepingfog, Step);

        if (_deceleration) Deceleration();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            e.TeleportEnemy(_positionCreepingfog);
            _deceleration = true;

            ps.MoveSpeed /= 2;
            ps.StatusOfVision = "��������� ������";
        }
    }

    private void Deceleration()
    {
        DecelerationTime -= Time.deltaTime;
        if (DecelerationTime < 0)
        {
            ps.MoveSpeed = _FirstMS;
            ps.StatusOfVision = _FirsStatusOfVision;
            _deceleration= false;
            DecelerationTime += _FirstTimeDeceleration;
        }
    }

}
