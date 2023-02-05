using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isHorizontalReverse = false;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private float _jumpWindUpDuration = 0.3f;
    [SerializeField] private float _interactWindUpDuration = 1.5f;
    [SerializeField] private Transform _groundCheckTrans;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private AudioSource _jumpSfx;
    [SerializeField] private BubbleDialog _dialog;
    public BubbleDialog BubbleDialog => _dialog;
    
    private CharacterAnimator _characterAnimator;

    public CharacterAnimator CharacterAnimator => _characterAnimator;

    private float _jumpTimestamp;
    private float _interactTimestamp;
    private bool _isTouchingLadder;
    private bool _isClimbing;
    private bool _isJumping;
    private Transform _touchingLadderObject;
    private bool _isInteracting;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterAnimator = GetComponentInChildren<CharacterAnimator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _dialog = GetComponentInChildren<BubbleDialog>();
    }

    private bool IsGrounded()
    {
        bool result = Physics.CheckSphere(_groundCheckTrans.position, 0.1f, _groundLayer);
        return result;
    }

    private void Update()
    {
        HandleHorizontalMovement();
        HandleJump();
        HandleClimb();
        // HandleInteract();
    }


    private void HandleHorizontalMovement()
    {
        if (_isClimbing || _isInteracting)
        {
            return;
        }

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
        if (_isInteracting) return;
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpForce, 0f);
            _characterAnimator.SetJump(true);
            _jumpTimestamp = Time.time;
            _isJumping = true;
            if (_jumpSfx != null)
            {
                _jumpSfx.PlayOneShot(_jumpSfx.clip);
            }
        }


        if (_isJumping)
        {
            if (_characterAnimator != null)
            {
                if (Time.time > _jumpTimestamp + _jumpWindUpDuration && IsGrounded())
                {
                    _characterAnimator.SetJump(false);
                    _isJumping = false;
                }
            }
        }
    }

    private void HandleClimb()
    {
        float verticalSpeed = Input.GetAxis("Vertical") * _moveSpeed;
        bool previousIsClimbing = _isClimbing;
        if (!_isClimbing)
        {
            if (_isTouchingLadder && Mathf.Abs(verticalSpeed) > 0.1f)
            {
                _isClimbing = true;
                Transform characterTransform;
                (characterTransform = transform).rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                Vector3 characterPosition = characterTransform.position;
                Vector3 clampXPos =
                    Vector3.Lerp(characterPosition,
                        new Vector3(_touchingLadderObject.position.x, characterPosition.y, 0f), 0.05f);
                characterPosition = clampXPos;
                characterTransform.position = characterPosition;
            }
        }


        if (_isClimbing)
        {
            if (_rigidbody.useGravity)
            {
                _rigidbody.useGravity = false;
            }

            _rigidbody.velocity = new Vector3(0f, verticalSpeed, 0f);
            bool isVerticalMoving = Mathf.Abs(_rigidbody.velocity.y) > 0.1f;
            if (isVerticalMoving)
            {
                _characterAnimator.Animator.speed = 1f;
            }
            else
            {
                _characterAnimator.Animator.speed = 0f;
            }

            if (!_isTouchingLadder || IsGrounded())
            {
                _isClimbing = false;
            }
        }
        else
        {
            if (!_rigidbody.useGravity)
            {
                _rigidbody.useGravity = true;
            }
        }


        if (previousIsClimbing != _isClimbing)
        {
            if (_characterAnimator != null)
            {
                _characterAnimator.SetClimb(_isClimbing);
            }
        }
    }

    // No need
    private void HandleInteract()
    {
        if (_isClimbing || _isJumping)
        {
            return;
        } 
        if (Input.GetKeyDown(KeyCode.E) && !_isInteracting)
        {
            _isInteracting = true;
            _interactTimestamp = Time.time;
            if (_characterAnimator != null)
            {
                _characterAnimator.SetInteract(_isInteracting);
            }
        }

        if (_isInteracting)
        {
            if (Time.time > _interactTimestamp + _interactWindUpDuration)
            {
                _isInteracting = false;
                if (_characterAnimator != null)
                {
                    _characterAnimator.SetInteract(_isInteracting);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            _touchingLadderObject = other.gameObject.transform;
            _isTouchingLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            _isTouchingLadder = false;
            _touchingLadderObject = null;
        }
    }
}