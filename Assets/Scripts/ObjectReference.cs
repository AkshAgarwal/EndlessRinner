using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

public class ObjectReference : MonoBehaviour
{
    #region Data Members
    //integer parameter to enter the distance where the tile must be disabled.
    [SerializeField] private float disableParameter;

    //Event data member.
    public event Action ObstacleSpawner;
    #endregion

    #region OnEnable and Update Functions
    public void OnEnable()
    {
        ObstacleSpawner?.Invoke();
    }

    //This function is used to deactivate tiles when player covers the distance of the length of a particular tile + disableParameter units extra.
    private void Update()
    {
        if(PlayerMovement.instance.transform.position.z > transform.position.z + disableParameter)
        {
            gameObject.SetActive(false);
        }
    }
    #endregion
}
