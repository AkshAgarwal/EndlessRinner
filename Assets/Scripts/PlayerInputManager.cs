using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInputManager : MonoBehaviour
{
    #region Action events
    //Action Events for Player Moving Left,Right,Jump
  [HideInInspector] public static event Action<bool> playerMove;
  [HideInInspector] public static event Action playerJump;
  [HideInInspector] public bool moveRight;
    #endregion

    #region Input listener
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
       
            playerMove?.Invoke(moveRight==true);
        }
        if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerMove?.Invoke(moveRight==false);
        }
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerJump?.Invoke();
        }
        if(Input.touches.Length>0)
        {
            Debug.Log(Input.touches[0].position);
        }
    }
    #endregion
}
