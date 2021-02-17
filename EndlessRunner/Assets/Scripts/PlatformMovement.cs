using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : EnviromentMovement
{
    private void Update()
    {
        Movement(PlatformManager.instance.m_EnviromentSpeed);
        CheckForDestroy(GameManager.instance.m_YBounds);
    }

    public override void Movement(float _speed)
    {
        base.Movement(_speed);
    }

    public override void CheckForDestroy(float _boundsY)
    {
        base.CheckForDestroy(_boundsY);
    }
}
