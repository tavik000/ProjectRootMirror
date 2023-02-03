using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleFaceObject : MonoBehaviour
{
    private float _currentZ;

    public float CurrentZ => _currentZ;

    public void MoveZ(float z)
    {
        _currentZ = z;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, _currentZ);
    }

}
