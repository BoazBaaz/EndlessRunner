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
    public LayerMask m_SpawnObstacles; //the layers of objects that disrupt the spawning prosses.
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
        /*List<string> names = new List<string>();
        for (int i = 0; i < 31; i++)
        {
            string layerName = LayerMask.LayerToName(i);
            //if (layerName == )

            string l = LayerMask.LayerToName(m_SpawnObstacles);


        }*/

        //coroutine gets repeated every 2 seconds using a While-statement, and cals the for-loop 2 times, which spawns in the given Object twice at given position.
        while (!GM.m_GameOver)
        {
            //get a random amout of platforms to spawn.
            int spawnAmount = Random.Range(1, m_MaxPlatforms + 1);

            for (int i = 0; i < spawnAmount; i++)
            {
                int platformType = Random.Range(0, m_Platforms.Length); //get a random betwean 0 and the m_platfroms.length - 1
                float platformX = Random.Range(-GM.m_XBounds, GM.m_XBounds); //get a random between the camera borders
                Collider2D platformCollider = m_Platforms[platformType].GetComponent<Collider2D>(); //the collider of the platform about to spawn

                //spawn a random platform, if possible.
                if (CalculateSpawnable(platformX, -GM.m_YBounds, platformCollider))
                    Instantiate(m_Platforms[platformType], new Vector2(platformX, -GM.m_YBounds), Quaternion.identity);
            }

            yield return new WaitForSeconds(m_SpawnDelay);
        }
    }

    /// <summary>
    /// Return true if the space is spawnable.
    /// </summary>
    /// <param name="_x">The X spawn position in world space.</param>
    /// <param name="_y">The Y spawn position in world space.</param>
    /// <param name="_col">The collider of the object trying to spawn.</param>
    /// <returns></returns>
    private bool CalculateSpawnable(float _x, float _y, Collider2D _col)
    {
        //get all the colliders in the spawn space.
         Collider2D[] obstacles = Physics2D.OverlapAreaAll(new Vector2(_x - _col.bounds.extents.x, _y + _col.bounds.extents.y),
                                                           new Vector2(_x + _col.bounds.extents.x, _y - _col.bounds.extents.y));

        //check if the colliders layers are in the m_SpawnObstacle layermask.
        foreach (var obst in obstacles)
        {
            int LayerToMask = 1 << obst.gameObject.layer;
            int SpawnObstacleMask = m_SpawnObstacles;

            int layer = LayerToMask & m_SpawnObstacles;

            if (layer != 0)
                return false;
        }

        return true;
    }
}
