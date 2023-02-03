using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(Vector3.right);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up);
        }

    }
}