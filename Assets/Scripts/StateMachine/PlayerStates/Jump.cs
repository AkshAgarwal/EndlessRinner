using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : States
{
   public Jump(PlayerMovement playerMovement):base(playerMovement)
    {
       
    }
    public override IEnumerator Jumping(bool isDead, float playerSpeed)
    {
       
        if (playerMovement.transform.position.y <= 0.06 && !isDead&&playerSpeed!=0f)
        {
            Debug.Log(playerSpeed);
            playerMovement.playerRigidBody.AddForce(Vector3.up * PlayerMovement._jumpForce, ForceMode.Impulse);
            playerMovement.playerAnimator.Play("Jumping");
        }
            yield return new WaitForSeconds(1.25f);
    }

}
