using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isHorizontalReverse = false;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal") * _moveSpeed;
        if (_isHorizontalReverse)
        {
            horizontalSpeed = -horizontalSpeed;
        }
        _rigidbody.velocity = new Vector3(horizontalSpeed, _rigidbody.velocity.y, 0f);

        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, 0f);
        }
    }
}