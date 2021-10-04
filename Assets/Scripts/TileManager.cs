using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TileManager : MonoBehaviour
{
    #region Data members
    public static Action ObstacleSpawner;
  
    //Float data members.
     public     float   zSpawn=0f;
     private    float   tilelength;

    //Integer Data Members.
     private  const  int InititalTiles = 8;
     private    float    xposition; 
     private    float    yposition; 
     private    float    zposition; 

    //Tile GameObject data members.
    [Header("Tile References")]
    [SerializeField]   private    GameObject   TilePrefab;
    [SerializeField]   private    GameObject   Tile;
    [SerializeField]   private    Transform   TileParent;

    //Player reference data members.
    [Header("Player Reference")]
    [SerializeField]   private    Transform    player;
    #endregion

    #region Start Function
    void Start()
    {

        //Initializations and spawning of Initial tiles in this case 5.
        xposition = -3.1834f;
        yposition = 0f;
        zposition = 1f;
        tilelength = 62.68f;
        Time.timeScale = 1;
        for (int i = 0; i < InititalTiles; i++)
        {
           var tile =  InititalTileSpawn();
           tile.SetActive(true);
        }
    }
    #endregion

    #region Update Function
    void Update()
    {
        // Infinite tile Spawn Logic. destructions script is present in each tile.

        if (player.position.z > zSpawn - (InititalTiles * tilelength))
        {
            Tile = ObjectPooler.ObjectPoolerInstance.GetPooledObjects();
            spawntile(Tile);
      
        }
       
    }
    #endregion

    #region Initial and Following Tile spawner and binder
    GameObject InititalTileSpawn()
    {
        // The function to spawn initial tiles.

        var tile = Instantiate(TilePrefab, new Vector3(xposition, yposition, zposition * zSpawn), transform.rotation);
        tile.transform.parent = TileParent;
        zSpawn += tilelength;
        tile.SetActive(false);
        return tile;
    }
    void spawntile(GameObject TileToBeBounded)
    {
        //Providing Bounds to the tiles that are being extracted and bound from the list of the Objectpooler of tiles.

        if(TileToBeBounded==null)
        {
            return;
        }
        TileToBeBounded.transform.position = new Vector3(xposition,yposition,zposition*zSpawn);
        TileToBeBounded.transform.rotation = transform.rotation;
        TileToBeBounded.SetActive(true);
        // TileToBeBounded.GetComponent<DeactivateTiles>().InvokeEvent();
        zSpawn += tilelength;
    }
    #endregion
}
