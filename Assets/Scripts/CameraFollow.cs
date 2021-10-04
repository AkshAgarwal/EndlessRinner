using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Data Members
    //Player and offset Reference
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0,4,-4);

    #endregion

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+offset.x, player.transform.position.y+offset.y, player.transform.position.z+offset.z);    
    }
}
