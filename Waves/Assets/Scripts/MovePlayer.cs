using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private bool _movingUp;
    public float Speed = 1;
    public float AngularSpeed = 1;
    private Rigidbody2D _rigidbody;
    public float _maxAngle = 60;
    private float targetAngle;
    private bool _dead;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        setup();
    }

    private void setup()
    {
        targetAngle = 60;
        _rigidbody.velocity = Vector3.right;
        _movingUp = true;
        _dead = false;
    }

    void Update()
    {
        if (!_dead && Input.GetKeyDown(KeyCode.Space))
        {
            targetAngle = -targetAngle;
            _movingUp = !_movingUp;
        }
    }

    void FixedUpdate()
    {
        if (_dead) return;
        if (_movingUp && _rigidbody.rotation < 60)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation + targetAngle * Time.fixedDeltaTime * AngularSpeed);
        }
        else if (!_movingUp && _rigidbody.rotation > -60)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation + targetAngle * Time.fixedDeltaTime * AngularSpeed);
        }
        _rigidbody.velocity = transform.right * Speed;
    }

    public void Die()
    {
        _dead = true;
        _rigidbody.velocity = Vector2.zero;
    }
}