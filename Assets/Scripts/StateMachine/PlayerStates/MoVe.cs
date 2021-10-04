using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoVe : States
{
  public MoVe(PlayerMovement playerMovement):base(playerMovement)
    {

    }
    public override IEnumerator Move(int desiredLane,bool isDead,float playerSpeed)
    {
        if(!isDead && playerSpeed!=0)
        {
            switch (desiredLane)
            {
                case 0:
                    playerMovement.pathCoordinate = -PlayerMovement._sideOffset;
                    break;
                case 1:
                    playerMovement.pathCoordinate = 0f;
                    break;
                case 2:
                    playerMovement.pathCoordinate = PlayerMovement._sideOffset;
                    break;

            }
            playerMovement.transform.position = new Vector3(playerMovement.pathCoordinate, playerMovement.transform.position.y, playerMovement.transform.position.z);
        }
       

            yield break;
        
    }
 
}
