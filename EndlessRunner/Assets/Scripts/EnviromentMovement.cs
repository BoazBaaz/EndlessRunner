using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour
{
    /// <summary>
    /// Move this object on the Y axis.
    /// </summary>
    /// <param name="_speed">The speed of this object while moveing.</param>
    public virtual void Movement(float _speed)
    {
        // Makes the platform move up multiplied by the given speed and Time.deltaTime to sync it.
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    /// <summary>
    /// Destory this object once it reaches the Y value in world space.
    /// </summary>
    /// <param name="_boundsY">The Y value at which to destroy.</param>
    public virtual void CheckForDestroy(float _boundsY)
    {
        // Makes the platform Destroy itself when above given index (out of camera view).
        if (transform.position.y >= _boundsY)
            Destroy(gameObject);
    }

    /// <summary>
    /// Set this object to the spawn Y value once it reaches the despawn Y value.
    /// </summary>
    /// <param name="_despawnValueY">The Y value at which to despawn in wrold space.</param>
    /// <param name="_spawnValueY">The Y value at which to spawn in world space.</param>
    public virtual void CheckForRespawn(float _despawnValueY, float _spawnValueY)
    {
        if (transform.position.y >= _despawnValueY)
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, _spawnValueY);
    }
}
