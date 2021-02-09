using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    private void Update()
    {
        MoveObject();

        CheckPosition();
    }

    public void MoveObject()
    {
        // Makes the platform move up multiplied by the given speed and Time.deltaTime to sync it.

        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    public void CheckPosition()
    {
        // Makes the platform Destroy itself when above given index (out of camera view).

        if (transform.position.y >= 5.5f)
        {
            Destroy(gameObject);
        }
    }
}
