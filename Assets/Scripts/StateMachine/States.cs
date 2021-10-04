using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States : MonoBehaviour
{
    //Player Movement reference is passed in a constructor to avoid adding class reference separately.
    public  PlayerMovement playerMovement;

    //Constructor that defaults this playerMovement reference to the reference of same name passed in constructor.
   public States(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public virtual IEnumerator Move(int desiredLane, bool isDead,float playerSpeed)
    {
        desiredLane = 0;
        yield break;
    }
  
    public virtual IEnumerator Jumping(bool isDead , float playerSpeed)
    {
        yield break;
    }
    public virtual IEnumerator playerDeath(GameObject player,Collision collision,GameObject deathmenu)
    {
        yield break;
    }

    public virtual IEnumerator Dead(GameObject player, MenuManager menuManager, int randomPlayerDeath,bool isDead,float playerSpeed,Animator playerAnimator)
    {
        yield break;
    }
}
