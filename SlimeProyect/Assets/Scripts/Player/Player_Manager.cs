using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{

    Player_Input player_Input;
    Player_Movement player_Movement;
    Player_Animations player_Animations;
    Player_Attack player_Attack;
    Rigidbody2D myRigidbody2D;
    BoxCollider2D myBoxCollider2D;



    public enum PlayerCharacterState { Idle, Run, Attack, jump, fall, land, wall, attack }
    public PlayerCharacterState playerState;


    private void Awake()
    {
        player_Input = gameObject.GetComponent<Player_Input>();
        player_Movement = gameObject.GetComponent<Player_Movement>();
        player_Animations = gameObject.GetComponent<Player_Animations>();
        player_Attack = gameObject.GetComponent<Player_Attack>();
        myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        myBoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        if (!player_Attack.IsAttacking)
        {
            if ((player_Input.isLeftPressed || player_Input.isRightPressed) && player_Movement.IsGrounded)
            {
                playerState = PlayerCharacterState.Run;
            }
            else if (player_Movement.IsJumping && !player_Movement.IsGrounded && !player_Movement.IsOnWallLeft && !player_Movement.IsOnWallRight)
            {
                playerState = PlayerCharacterState.jump;
            }
            else if (!player_Movement.IsJumping && !player_Movement.IsGrounded && !player_Movement.IsLanding && !player_Movement.IsOnWallLeft && !player_Movement.IsOnWallRight)
            {
                playerState = PlayerCharacterState.fall;
            }
            else if (player_Movement.IsLanding && !player_Movement.IsJumping && player_Movement.IsGrounded)
            {
                playerState = PlayerCharacterState.land;
            }
            else if (!player_Movement.IsGrounded && (player_Movement.IsOnWallLeft || player_Movement.IsOnWallRight))
            {
                if (player_Movement.IsOnWallLeft && !player_Input.isRightPressed)
                {
                    playerState = PlayerCharacterState.wall;
                }
                if (player_Movement.IsOnWallRight && !player_Input.isLeftPressed)
                {
                    playerState = PlayerCharacterState.wall;
                }

            }
            else
            {
                playerState = PlayerCharacterState.Idle;
            }
        }
        else
        {
            if (player_Movement.IsOnWallRight)
            {
                if (player_Attack.AttackDirection == 1)
                {
                    playerState = PlayerCharacterState.Idle;
                }
                else
                {
                    playerState = PlayerCharacterState.attack;
                }
            }
            else if (player_Movement.IsOnWallLeft)
            {
                if (player_Attack.AttackDirection == 2)
                {
                    playerState = PlayerCharacterState.Idle;
                }
                else
                {
                    playerState = PlayerCharacterState.attack;
                }
            }
            else 
            {
              
              playerState = PlayerCharacterState.attack;
                
            }


        }
        UpdateAnimations();

    }

    void UpdateAnimations()
    {
        if (playerState == PlayerCharacterState.Idle)
        {
            player_Animations.changeState(player_Animations.PLAYER_IDLE);
        }
        else if (playerState == PlayerCharacterState.Run)
        {
            player_Animations.changeState(player_Animations.PLAYER_RUN);
        }
        else if (playerState == PlayerCharacterState.jump)
        {
            player_Animations.changeState(player_Animations.PLAYER_JUMP);
        }
        else if (playerState == PlayerCharacterState.fall)
        {
            player_Animations.changeState(player_Animations.PLAYER_FALL);
        }
        else if (playerState == PlayerCharacterState.land)
        {
            player_Animations.changeState(player_Animations.PLAYER_LAND);
        }
        else if (playerState == PlayerCharacterState.wall)
        {
            player_Animations.changeState(player_Animations.PLAYER_WALL);
        }
        else if (playerState == PlayerCharacterState.attack)
        {
            player_Animations.changeState(player_Animations.PLAYER_GLATTTACK);
        }

    }
    // Get Private Components

    public Rigidbody2D getRigidbody2D()
    {
        return myRigidbody2D;
    }

    public Player_Input getPlayer_Input()
    {
        return player_Input;
    }
    public Player_Movement getPlayer_Movement()
    {
        return player_Movement;
    }

    public Player_Attack getPlayer_Attack()
    {
        return player_Attack;
    }

    public BoxCollider2D getBoxCollider2D()
    {
        return myBoxCollider2D;
    }

    
}
