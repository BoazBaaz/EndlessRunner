using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject Object;

    private float platformX;
    private float platformY = -6.0f;

    private void Start()
    {
        // Set variables to a random float between given indexes, and starts coroutine.

        platformX = Random.Range(-8.88f, 8.88f);

        StartCoroutine("SpawnPlatforms");
    }

    private void Update()
    {
        if (GameManager.instance.isDead)
        {
            StopCoroutine("SpawnPlatforms");
        }
    }

    IEnumerator SpawnPlatforms()
    {
        // Coroutine gets repeated every 2 seconds using a While-statement, and cals the for-loop 2 times, which spawns in the given Object twice at given pos.
        while (true)
        {

            for (int i = 0; i < 2; i++)
            {
                platformX = Random.Range(-8.88f, 8.88f);
                Instantiate(Object, new Vector2(platformX, platformY), Quaternion.identity);
            }
            yield return new WaitForSeconds(2);
        }

    }
}
