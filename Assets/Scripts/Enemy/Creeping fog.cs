using UnityEngine;

public class creepingfog : MonoBehaviour
{
    // Крадущийся туман: Создаёт облачность, которая затрудняет движение и видимость.

    public Enemies e;
    public PlayerStats ps;

   
    public float DecelerationTime;  // время замедления
    private Transform _positionCreepingfog;
    private bool _deceleration;
    private float _FirstTimeDeceleration;
    private float _FirstMS;
    private string _FirsStatusOfVision;



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
        if (_deceleration) Deceleration();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            e.TeleportEnemy(_positionCreepingfog);
            _deceleration = true;

            ps.MoveSpeed /= 2;
            ps.StatusOfVision = "Видимость плохая";
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
