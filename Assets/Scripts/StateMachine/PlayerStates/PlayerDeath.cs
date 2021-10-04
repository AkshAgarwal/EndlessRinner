using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : States
{
    private string animationName;
    private float waitForSeconds;
    public PlayerDeath(PlayerMovement playerMovement):base(playerMovement)
    {
     
    }
    public override IEnumerator Dead(GameObject player, MenuManager menuManager,int randomPlayerDeath,bool isDead,float playerSpeed,Animator playerAnimator)
    {
        if (playerSpeed <= 0 && isDead)
        {
            switch (randomPlayerDeath)
            {
                case 0:
                    animationName = "Standing React Death Backward";
                    waitForSeconds = 3.15f;
                    break;
                case 1:
                    animationName = "Dying Backwards";
                    waitForSeconds =4.15f;
                    break;
                case 2:
                    animationName = "Falling Back Death";
                    waitForSeconds = 2.15f;
                    break; 
            }
            playerAnimator.Play(animationName);
        }
        yield return new WaitForSeconds(waitForSeconds);
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
            menuManager.DeathMenu();
            Time.timeScale = 0f;
    }


}
