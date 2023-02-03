using System;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isHorizontalReverse = false;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rigidbody;

    private CharacterAnimator _characterAnimator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterAnimator = GetComponentInChildren<CharacterAnimator>();
    }

    private void Update()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal") * _moveSpeed;
        if (_isHorizontalReverse)
        {
            horizontalSpeed = -horizontalSpeed;
        }

        _rigidbody.velocity = new Vector3(horizontalSpeed, _rigidbody.velocity.y, 0f);
        if (Mathf.Abs(horizontalSpeed) > 0.01f)
        {
            transform.rotation =
                Quaternion.LookRotation(horizontalSpeed > 0f ? Vector3.right : Vector3.left, Vector3.up);
        }

        _characterAnimator.SetMoveSpeed(Mathf.Abs(_rigidbody.velocity.x));

        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, 0f);
        }
    }
}