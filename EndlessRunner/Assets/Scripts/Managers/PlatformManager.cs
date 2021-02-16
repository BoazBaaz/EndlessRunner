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
    public float m_EnviromentSpeed = 4f; //the speed used for the platforms and background

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

            //make an array for all the bounds od the spawned platforms
            PlatformBounds[] boundsArray = new PlatformBounds[spawnAmount];

            for (int i = 0; i < spawnAmount; i++)
            {
                //get a random betwean 0 and the m_platfroms.length - 1
                int platformType = Random.Range(0, m_Platforms.Length);

                //get a random between the camera borders
                float platformX = Random.Range(-GM.m_XBounds, GM.m_XBounds);

                //spawn a random platform
                GameObject platform = Instantiate(m_Platforms[platformType], new Vector2(platformX, -GM.m_YBounds), Quaternion.identity);
                Collider2D platformCollider = platform.GetComponent<Collider2D>();

                //add the plaform to the boundsArray
                boundsArray[i] = new PlatformBounds(platform.gameObject,
                                                    platform.transform.position.x - platformCollider.bounds.extents.x,
                                                    platform.transform.position.x + platformCollider.bounds.extents.x);
            }

            PlatformOverlapsCheck(boundsArray);

            yield return new WaitForSeconds(m_SpawnDelay);
        }
    }

    private void PlatformOverlapsCheck(PlatformBounds[] _boundsArray)
    {
        //delete one of the platforms if its bounds are overlaping
        for (int i = 0; i < _boundsArray.Length; i++)
        {
            if (_boundsArray[i].leftBound < -GM.m_XBounds || _boundsArray[i].rightBound > GM.m_XBounds)
                Destroy(_boundsArray[i].platform);

            if (i != 0)
            {
                if (_boundsArray[i].leftBound > _boundsArray[i - 1].leftBound && _boundsArray[i].leftBound < _boundsArray[i - 1].rightBound)
                    Destroy(_boundsArray[i].platform);
                if (_boundsArray[i].rightBound < _boundsArray[i - 1].rightBound && _boundsArray[i].rightBound > _boundsArray[i - 1].leftBound)
                    Destroy(_boundsArray[i].platform);
            }
        }
    }

    private struct PlatformBounds
    {
        public PlatformBounds(GameObject _platform, float _left, float _right)
        {
            platform = _platform;
            leftBound = _left;
            rightBound = _right;
        }

        public GameObject platform;
        public float leftBound;
        public float rightBound;
    }

}
