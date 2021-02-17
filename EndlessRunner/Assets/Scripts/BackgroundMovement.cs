using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : EnviromentMovement
{
    private void Update()
    {
        Movement(PlatformManager.instance.m_EnviromentSpeed);
        CheckForRespawn(GameManager.instance.m_BackgroundDespawnY, GameManager.instance.m_BackgroundSpawnY);
    }

    public override void Movement(float _speed)
    {
        base.Movement(_speed);
    }

    public override void CheckForRespawn(float _despawnValueY, float _spawnValueY)
    {
        base.CheckForRespawn(_despawnValueY, _spawnValueY);
    }
}
