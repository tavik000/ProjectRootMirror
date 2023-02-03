using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeMovingPlatform : MovingPlatform
{
    protected override void HandleMovement()
    {
        _value = Mathf.Min(MoveSeconds * 1f / MoveDuration, 1);
        base.HandleMovement();
    }
}
