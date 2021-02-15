using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private void Update()
    {
        MoveObject();

        CheckPosition();
    }

    public void MoveObject()
    {
        // Makes the platform move up multiplied by the given speed and Time.deltaTime to sync it.

        transform.Translate(Vector2.up * PlatformManager.instance.m_EnviromentSpeed * Time.deltaTime);
    }

    public void CheckPosition()
    {
        // Makes the platform Destroy itself when above given index (out of camera view).

        if (transform.position.y >= GameManager.instance.m_YBounds)
        {
            Destroy(gameObject);
        }
    }
}
