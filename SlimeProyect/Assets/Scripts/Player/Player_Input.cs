﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    [SerializeField] internal Player_Manager player_Manager;

   [SerializeField] internal bool isLeftpressed;
   [SerializeField] internal bool isRightpressed;
    [SerializeField] internal bool JumpPressed;


    void Update()
    { 
        if (Input.GetAxisRaw("Horizontal") == 1){
            isRightpressed = true;
            
        } else {
            isRightpressed = false;
            
        }

        if (Input.GetAxisRaw("Horizontal") == -1){
            isLeftpressed = true;
            
        } else {
            isLeftpressed = false;
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_Manager.player_Movment.MoveCharacter(0, true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            player_Manager.player_Movment.MoveCharacter(0, true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player_Manager.player_Movment.isJumping = false;
        }


    }


}