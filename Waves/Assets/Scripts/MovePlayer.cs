using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    private bool _movingUp;
    public float Speed = 1;
    public float SpeedIncrease = 1;
    public float AngularSpeed = 1;
    private Rigidbody _rigidbody;
    public float _maxAngle = 60;
    private float _targetAngle;
    private bool _dead;
    public ParticleSystem DeathParticleSystem;
    public ParticleSystem GlowParticleSystem;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _targetAngle = 60;
        _rigidbody.velocity = Vector3.right;
        _movingUp = true;
        _dead = false;
    }

    void Update()
    {
        if (!_dead && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
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
            RotatePlayer();
        }
        else if (!_movingUp && (_rigidbody.rotation.eulerAngles.z < 90 || _rigidbody.rotation.eulerAngles.z > 300))
        {
            RotatePlayer();
        }
        _rigidbody.velocity = transform.right * Speed;
    }

    private void RotatePlayer()
    {
        Quaternion deltaRotation = Quaternion.Euler(0, 0, _targetAngle * Time.deltaTime * AngularSpeed);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    }

    public void IncreaseSpeed()
    {
        Speed += SpeedIncrease;
    }
    public void Die()
    {
        _dead = true;
        GetComponent<SpriteRenderer>().enabled = false;
        _rigidbody.isKinematic = true;
        DeathParticleSystem.Play(true);
        GlowParticleSystem.Stop(true);

        _rigidbody.velocity = Vector2.zero;
    }
}