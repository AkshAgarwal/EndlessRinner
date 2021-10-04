using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DeactivateObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    #region Data Members
    public event Action ObstacleSpawner;
    [SerializeField] private float DisableParameter;
    #endregion

    //Invoke method to invoke the event on call.
    public void InvokeEvent()
    {
        ObstacleSpawner?.Invoke();
        Debug.LogError(" " + ObstacleSpawner.GetInvocationList().Length);
    }

    //This function is used to deactivate tiles when player covers the distance of the length of a particular tile + 80 units extra.
    void Update()
    {
        if (PlayerMovement.instance.transform.position.z > transform.position.z + DisableParameter)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(transform.position.z, transform.position.y, transform.position.z + 1f);
        }
    }
}
