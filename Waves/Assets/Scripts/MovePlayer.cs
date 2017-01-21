using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float _time;
    private Vector3 _targetVector = Vector3.up;
    private Vector3 _previousDirection = Vector3.right;
    private bool _transitioning;
    private bool _up = true;
    public float Speed = 1;
    public float AngularSpeed = 1;
    private float _Angle;

    void Start()
    {
        _time = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_transitioning)
            {
                _previousDirection = GetDirection();
                _targetVector = Vector3.right;
                _time = Time.time;
                _transitioning = true;
            }
            else
            {
                _previousDirection = GetDirection();
                _time = Time.time;
                _transitioning = false;
                if (_up)
                {
                    _targetVector = Vector3.up;
                }
                else
                {
                    _targetVector = Vector3.down;
                }
            }
            _Angle = Vector3.Angle(_previousDirection, _targetVector);
        }
        if (_transitioning)
        {
            Vector3 direction = GetDirection();
            Debug.Log("Trans: " + Vector3.Angle(direction, _targetVector));
            transform.position += direction * Time.deltaTime * Speed;
            if (Vector3.Angle(direction, _targetVector) < 5f)
            {
                _time = Time.time;
                _previousDirection = Vector3.right;
                _up = !_up;
                if (_up)
                {
                    _targetVector = Vector3.up;
                }
                else
                {
                    _targetVector = Vector3.down;
                }
                _transitioning = false;
            }
        }
        else
        {
            Vector3 direction = GetDirection();
            Debug.Log(Vector3.Angle(direction, _targetVector));
            transform.position += direction * Time.deltaTime * Speed;
        }
    }

    private Vector3 GetDirection()
    {
        return Vector3.Slerp(_previousDirection, _targetVector,
            (Time.time - _time) / _Angle * 90 / (1f / AngularSpeed) * Speed);
    }
}