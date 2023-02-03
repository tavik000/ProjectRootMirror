using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMovingPlatform : MovingPlatform
{
    protected override void HandleMovement()
    {
        _value = Mathf.PingPong(MoveSeconds * 1f / MoveDuration, 1);
        base.HandleMovement();
    }
}
