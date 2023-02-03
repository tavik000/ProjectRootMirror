using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraManager : SingletonManager<CameraManager>
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform adult;
    [SerializeField] private Transform kid;
    [SerializeField] private float maxRotationDegree;
    
    private Camera _camera;
    private bool _forward;
    
    private void Start()
    {
        _camera = Camera.main;
        _forward = true;
    }

    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        Vector3 targetDir = _forward ? Vector3.forward : -Vector3.forward;
        pivot.forward = Vector3.RotateTowards(pivot.forward, targetDir, 
            maxRotationDegree * Time.deltaTime * Mathf.Deg2Rad, 1);
    }

    private void UpdateMovement()
    {
        Vector3 targetPos = (adult.transform.position + kid.transform.position) / 2;
        pivot.position = Vector3.Lerp(pivot.position, targetPos, 0.01f);
    }

    public void Rotate180()
    {
        _forward = !_forward;
        
    }
}




