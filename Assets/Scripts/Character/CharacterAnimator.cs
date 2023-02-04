using System;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator = null;

    public Animator Animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }

            return _animator;
        }
    }


    private readonly int _moveSpeedHash = Animator.StringToHash("MoveSpeed");
    private readonly int _jumpHash = Animator.StringToHash("IsJumping");
    private readonly int _climbHash = Animator.StringToHash("IsClimbing");
    private readonly int _interactHash = Animator.StringToHash("IsInteracting");

    public void SetMoveSpeed(float moveSpeed)
    {
        Animator.SetFloat(_moveSpeedHash, moveSpeed);
    }

    public void SetJump(bool value)
    {
        _animator.SetBool(_jumpHash, value);
    }
    
    public void SetClimb(bool value)
    {
        _animator.SetBool(_climbHash, value);
    }
    
    public void SetInteract(bool value)
    {
        _animator.SetBool(_interactHash, value);
    }
}