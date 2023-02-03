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


    private int _moveSpeed = Animator.StringToHash("MoveSpeed");

    public void SetMoveSpeed(float moveSpeed)
    {
        Animator.SetFloat(_moveSpeed, moveSpeed);
    }
}