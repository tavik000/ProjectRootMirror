using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : DoubleFaceObject
{
    [SerializeField] private Vector2 moveOffset;
    [SerializeField] private float moveDuration = 1f;
    public float MoveDuration => moveDuration;
    [SerializeField] private bool _isActive;

    private Rigidbody _rigidbody;
    private SignalReceiver _signalReceiver;
    private Vector2 _originalPos;
    private float _moveSeconds;
    public float MoveSeconds => _moveSeconds;

    protected float _value;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _signalReceiver = GetComponent<SignalReceiver>();
        _signalReceiver.SignalEvent += ActivePlatform;
        _isActive = false;
        _originalPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        if (_isActive)
        {
            _moveSeconds += Time.fixedDeltaTime;
            HandleMovement();
        }
    }

    public void ActivePlatform(bool isActive)
    {
        _isActive = isActive;
    }

    protected virtual void HandleMovement()
    {
        MoveTo(_value);
    }

    protected void MoveTo(float value) // 0-1
    {
        Vector2 targetPos = _originalPos + value * moveOffset;
        _rigidbody.MovePosition(targetPos);
    }

    // void OnDrawGizmosSelected()
    // {
    //     // Draw a yellow sphere at the transform's position
    //     Gizmos.color = Color.yellow;
    //     if (EditorApplication.isPlaying)
    //     {
    //         Gizmos.DrawSphere(new Vector3(_originalPos.x + moveOffset.x,
    //             _originalPos.y + moveOffset.y, transform.position.z), 0.5f);
    //     }
    //     else
    //     {
    //         Gizmos.DrawSphere(transform.position + 
    //                           new Vector3(moveOffset.x, moveOffset.y, 0), 0.5f);
    //
    //     }
    // }
}