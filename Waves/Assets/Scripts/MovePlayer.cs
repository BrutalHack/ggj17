using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private bool _movingUp;
    public float Speed = 1;
    public float AngularSpeed = 1;
    private Rigidbody _rigidbody;
    public float _maxAngle = 60;
    private float _targetAngle;
    private bool _dead;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        setup();
    }

    private void setup()
    {
        _targetAngle = 60;
        _rigidbody.velocity = Vector3.right;
        _movingUp = true;
        _dead = false;
    }

    void Update()
    {
        if (!_dead && Input.GetKeyDown(KeyCode.Space))
        {
            _targetAngle = -_targetAngle;
            _movingUp = !_movingUp;
        }
    }

    void FixedUpdate()
    {
        if (_dead)
        {
            return;
        }
        if (_movingUp && (_rigidbody.rotation.eulerAngles.z < 60 || _rigidbody.rotation.eulerAngles.z > 270))
        {
            Quaternion deltaRotation = Quaternion.Euler(0, 0, _targetAngle * Time.deltaTime * AngularSpeed);
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }
        else if (!_movingUp && (_rigidbody.rotation.eulerAngles.z < 90 || _rigidbody.rotation.eulerAngles.z > 300))
        {
            Quaternion deltaRotation = Quaternion.Euler(0, 0, _targetAngle * Time.deltaTime * AngularSpeed);
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }
        _rigidbody.velocity = transform.right * Speed;
    }

    public void Die()
    {
        _dead = true;
        _rigidbody.velocity = Vector2.zero;
    }
}