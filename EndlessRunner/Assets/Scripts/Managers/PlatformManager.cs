using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [Header("SpawnInfo")]
    public GameObject[] m_Platforms; //the array of the platforms to use
    public float m_SpawnDelay = 2f; //spawn delay is seconds
    public int m_MaxPlatforms = 2; //max platforms to spawn
    public float m_PlatformY = -7.0f; //the Y the platforms spawn at

    //private
    private GameManager GM;

    private void Start()
    {
        //instance of the gamemanager
        GM = GameManager.instance;

        //start coroutine.
        StartCoroutine(SpawnPlatforms());
    }

    IEnumerator SpawnPlatforms()
    {
        // Coroutine gets repeated every 2 seconds using a While-statement, and cals the for-loop 2 times, which spawns in the given Object twice at given pos.
        while (!GM.m_GameOver)
        {
            //get a random amout of platforms to spawn
            int spawnAmount = Random.Range(1, m_MaxPlatforms + 1);

            for (int i = 0; i < spawnAmount; i++)
            {
                //get a random betwean 0 and the m_platfroms.length - 1
                int platformType = Random.Range(0, m_Platforms.Length);

                //get a random between the camera borders
                float platformX = Random.Range(-8.88f, 8.88f);

                //spawn a random platform
                Instantiate(m_Platforms[platformType], new Vector2(platformX, m_PlatformY), Quaternion.identity);
            }
            yield return new WaitForSeconds(m_SpawnDelay);
        }
    }
}
