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
    private bool _isTouchingLadder;

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
        HandleClimb();
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

        if (_characterAnimator != null)
        {
            _characterAnimator.SetMoveSpeed(Mathf.Abs(_rigidbody.velocity.x));
        }
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, 0f);
            _characterAnimator.SetJump(true);
            _jumpTimestamp = Time.time;
        }


        if (_characterAnimator != null)
        {
            if (Time.time > _jumpTimestamp + _jumpWindUpDuration && IsGrounded())
            {
                _characterAnimator.SetJump(false);
            }
        }
    }

    private void HandleClimb()
    {
        float verticalSpeed = Input.GetAxis("Vertical") * _moveSpeed;

        if (_isTouchingLadder && Mathf.Abs(verticalSpeed) > 0.1f)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, verticalSpeed, 0f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            _isTouchingLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            _isTouchingLadder = false;
        }
    }
}