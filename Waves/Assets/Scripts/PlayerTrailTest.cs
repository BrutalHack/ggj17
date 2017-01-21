using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerTrailTest : MonoBehaviour {
    private Rigidbody2D _rigidBody;
    private float _timer = 0f;
    private float _interval = 2f;

    [SerializeField]
    private float _speed = 3;

    // Use this for initialization
	void Start () {
	    _rigidBody = GetComponent<Rigidbody2D>();
	    _rigidBody.velocity = new Vector2(2, _speed);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (_timer > _interval)
	    {
	        _timer -= _interval;
	        _rigidBody.velocity = new Vector2(2, _speed*-1);
	    }
	    _timer += Time.deltaTime;
	    Debug.Log(_timer);
	}
}
