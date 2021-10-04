using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ObjectPooler : MonoBehaviour
{
    #region Data Members
    //Const integers for Maximum no of tiles and maximum no of tiles in the pool
    private const int maxNoOfTiles = 8;
    private const int maxNumberOfObstacles = 100;

    //Tile prefab References
    [Header("PrefabReferences")]
    [SerializeField] private GameObject TilePrefab;
    [SerializeField] private GameObject[] ObstaclePrefabs;

    //Obstacle prefab references
    [Header("PrefabParentReferences")]
    [SerializeField] private Transform obstaclePrefabParent;
    [SerializeField] private Transform tilePrefabParent;
    #endregion

    #region Singleton Instance of Objectpooler class
    //Singleton instance Of ObjectPooler Class
    public static ObjectPooler ObjectPoolerInstance;
    #endregion

    #region Pool list of tiles and obstacles
    //Declaration of List that is going to hold and pool tiles.
    private List<GameObject> TileHolderList = new List<GameObject>();
    private List<GameObject> ObstacleHolderList = new List<GameObject>();
    #endregion

    #region OnEnable and Awake Functions
    private void Awake()
    {
        ObjectPoolerInstance = this;
    }
   
    void OnEnable()
    {
        //Initialization of the list that is going to hold and pool tiles.
        TileHolderList = FillList(maxNoOfTiles, TilePrefab, tilePrefabParent);
        ObstacleHolderList = FillList(maxNumberOfObstacles, ObstaclePrefabs, obstaclePrefabParent);
    }
    #endregion

    #region Pool creation of tiles and obstacles
    private List<GameObject> FillList(int maxValue, GameObject prefab, Transform prefabParent)
    {
        var tempList = new List<GameObject>();
        for (var i = 0; i < maxValue; i++)
        {
            var obj = Instantiate(prefab, prefabParent);
            tempList.Add(obj);
            obj.SetActive(false);
        }
        return tempList;
    }
    
    private List<GameObject> FillList(int maxValue, GameObject[] prefab, Transform prefabParent)
    {
        var tempList = new List<GameObject>();
        for (var i = 0; i < maxValue; i++)
        {
            var rangeOutput = Random.Range(0, prefab.Length);
            var obj = Instantiate(prefab[rangeOutput], prefabParent);
            tempList.Add(obj);
            obj.SetActive(false);
        }
        return tempList;
    }
    #endregion

    #region Returning pool objects of tiles and lists
    //Pooler function to be called by 'TileManager' script to spawn tiles.
    public GameObject GetPooledObjects()
    {
        return TileHolderList.Find(a => !a.activeInHierarchy);
    }
    //Pooler function to be called by 'ObstacleSpawner' script to spawn tiles.
    public GameObject GetObstacles()
    {
       return ObstacleHolderList.Find(a => !a.activeInHierarchy);
    }
    #endregion
}
