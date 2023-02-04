using System;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isHorizontalReverse = false;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private float _jumpWindUpDuration = 0.3f;

    private CharacterAnimator _characterAnimator;

    private float _jumpTimestamp;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterAnimator = GetComponentInChildren<CharacterAnimator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private bool IsGrounded()
    {
        const float threshold = 0.1f;
        float distanceToGround = _capsuleCollider.height / 2f;
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround + threshold);
    }

    private void Update()
    {
        HandleHorizontalMovement();
        HandleJump();
    }

    
    private void HandleHorizontalMovement()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal") * _moveSpeed;
        if (_isHorizontalReverse)
        {
            horizontalSpeed = -horizontalSpeed;
        }

        _rigidbody.velocity = new Vector3(horizontalSpeed, _rigidbody.velocity.y, 0f);
        if (Mathf.Abs(horizontalSpeed) > 0.1f)
        {
            transform.rotation =
                Quaternion.LookRotation(horizontalSpeed > 0f ? Vector3.right : Vector3.left, Vector3.up);
        }

        _characterAnimator.SetMoveSpeed(Mathf.Abs(_rigidbody.velocity.x));
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, 0f);
            _characterAnimator.SetJump(true);
            _jumpTimestamp = Time.time;
        }

        if (Time.time > _jumpTimestamp + _jumpWindUpDuration && IsGrounded())
        {
            _characterAnimator.SetJump(false);
        }
    }
}