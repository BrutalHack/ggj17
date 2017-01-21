using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private bool _movingUp;
    public float Speed = 1;
    public float AngularSpeed = 1;
    private Rigidbody2D _rigidbody;
    public float _maxAngle = 60;
    private float targetAngle;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        targetAngle = 60;
        _rigidbody.velocity = Vector3.right;
        _movingUp = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetAngle = -targetAngle;
            _movingUp = !_movingUp;
        }
    }

    void FixedUpdate()
    {
        Debug.Log(_rigidbody.rotation);
        if (_movingUp && (_rigidbody.rotation < 60 || _rigidbody.rotation > 270))
        {
            _rigidbody.MoveRotation((_rigidbody.rotation + targetAngle) * Time.fixedDeltaTime * AngularSpeed);
        }
        else if (!_movingUp && (_rigidbody.rotation < 90 || _rigidbody.rotation > 300))
        {
            _rigidbody.MoveRotation((_rigidbody.rotation + targetAngle) * Time.fixedDeltaTime * AngularSpeed);
        }
        _rigidbody.velocity = transform.right * Speed;
    }
}