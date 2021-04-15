using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{

    [SerializeField] internal Player_Input player_Input;
    [SerializeField] internal Player_Movment player_Movment;
    [SerializeField] internal Player_animationcontroller player_Animationcontroller;
     public enum PlayerState {Idle, Run, Attack, jump, fall, land, wall}
    public PlayerState playerState;


    public Rigidbody2D rb2D;
    public BoxCollider2D myBoxCollider;
    public bool isGrounded;


    private void Start()
    {
        myBoxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        CheckState();
    }


    public void CheckState()
    {
        if (player_Movment.isGrounded)
        {
            if (player_Input.isRightpressed || player_Input.isLeftpressed )
            {
                playerState = PlayerState.Run;
                player_Animationcontroller.changeState(player_Animationcontroller.PLAYER_RUN, false, 0);
            }
            else if (!player_Input.isRightpressed && !player_Input.isLeftpressed && !player_Movment.isLanding)
            {
                playerState = PlayerState.Idle;
                player_Animationcontroller.changeState(player_Animationcontroller.PLAYER_IDLE, false, 0);
            }
            else if (!player_Input.isRightpressed && !player_Input.isLeftpressed && player_Movment.isLanding)
            {
                playerState = PlayerState.land;
                player_Animationcontroller.changeState(player_Animationcontroller.PLAYER_LAND, false, 0);

            }
        }
        else if (!player_Movment.isGrounded && player_Movment.isJumping && !player_Movment.WallLeft && !player_Movment.WallRight)
        {
            playerState = PlayerState.jump;
            player_Animationcontroller.changeState(player_Animationcontroller.PLAYER_JUMP, false, 0 );
        }
        else if (!player_Movment.isGrounded && !player_Movment.isJumping && !player_Movment.isLanding && !player_Movment.WallLeft && !player_Movment.WallRight)
        {
            playerState = PlayerState.fall;
            player_Animationcontroller.changeState(player_Animationcontroller.PLAYER_FALL, true, 0.2f);
        }
        else if ((player_Movment.WallLeft || player_Movment.WallRight) && !player_Movment.isJumping)
        {
            playerState = PlayerState.wall;
            player_Animationcontroller.changeState(player_Animationcontroller.PLAYER_WALL, false, 0);
            
        }

       
    }



    
}
