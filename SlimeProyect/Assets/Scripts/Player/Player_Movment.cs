using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
    [SerializeField] internal Player_Manager player_Manager;
    [SerializeField] internal float speed = 100;
    [SerializeField] private float JumpForce = 400f;

    [SerializeField] private LayerMask platformLayerMask;

    public float disToGround = 1f;
    public bool isGrounded = false;
    public bool isJumping = false;
    private float JumpBoostMaxTime = 0.35f;
    private float jumpboostTimer;
    private bool m_FacingRight = true;

    //landing
    private bool WasInTheAir;
    public bool isLanding;
    private float LandTime = 0.5f;

    //Wall
    public bool WallLeft;
    public bool WallRight;
    public bool canWallJump;
    public bool WallJumpLeft;
    public bool WallJumpRight;



    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;


    private void FixedUpdate()
    {

        int WallColissionDirection;
        if (WallCheck(out WallColissionDirection) && !isGrounded && !isJumping && player_Manager.rb2D.velocity.y <= 0)
        {
            
            if (WallColissionDirection == 1) // wall left
            {
               

                WallLeft = true;
                WallRight = false;
                player_Manager.rb2D.gravityScale = 0.5f;
                if (m_FacingRight)
                {
                    Flip();
                }
                // set animator wall left

            }
            else if (WallColissionDirection == 2) //wall right
            {


                WallLeft = false;
                WallRight = true;
                player_Manager.rb2D.gravityScale = 0.5f;
                if (!m_FacingRight)
                {
                    Flip();
                }
                // set animator wall right

            }
        }

        else
        {
          
            player_Manager.rb2D.gravityScale = 5f;
            WallLeft = false;
            WallRight = false;
         

        }
      
        if (player_Manager.player_Input.isRightpressed && isGrounded && !WallRight)
        {

            MoveCharacter(speed, false);
           

        } else if (player_Manager.player_Input.isRightpressed && !isGrounded && !WallRight && !WallJumpRight)
        {
            MoveCharacter(speed / 2, false);
            
        }
        else if (player_Manager.player_Input.isLeftpressed && isGrounded && !WallLeft)
        {
            MoveCharacter(-speed, false);
          

        } else if (player_Manager.player_Input.isLeftpressed && !isGrounded && !WallLeft && !WallJumpLeft)
        {
            MoveCharacter(-speed / 2, false);

        } 
       

        if (GroundCheck())
        {
            isGrounded = true;

            if (WasInTheAir)
            {
                isLanding = true;
                Invoke("PlayerLanding", LandTime);
                WasInTheAir = false;
                
            }
        }
        else
        {
            WasInTheAir = true;
            isGrounded = false;
            
        }

        if (isJumping)
        {
            if (RoofCheck())
            {
                isJumping = false;
                jumpboostTimer = 0;
            }
        }

       

        
    }

    public void MoveCharacter(float move, bool jump)
    {
        // Move

        if (!WallLeft && !WallRight)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, player_Manager.rb2D.velocity.y);
            player_Manager.rb2D.velocity = Vector3.SmoothDamp(player_Manager.rb2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        

        if (move > 0 && !m_FacingRight && !WallLeft)
        { 
            Flip();
        }
       
        else if (move < 0 && m_FacingRight && !WallRight)
        {
            Flip();
        }


   
        

        //Jump

        
        if (isGrounded && jump)
        {
            player_Manager.rb2D.velocity =  new Vector2(player_Manager.rb2D.velocity.x, JumpForce);
           
            jumpboostTimer = JumpBoostMaxTime;
            isJumping = true;
            WasInTheAir = true;

        }
        if (isJumping && jump && !WallLeft && !WallRight && !WallJumpLeft && !WallJumpRight)
        {
            if (jumpboostTimer > 0)
            {
                
                player_Manager.rb2D.velocity = new Vector2(player_Manager.rb2D.velocity.x, JumpForce);
                jumpboostTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (WallLeft && move > 0 && jump && !isGrounded && !player_Manager.player_Input.isLeftpressed)
        {
            WallJumpLeft = true;
            Invoke("EndWallJump",  0.5f);
            Flip();
            isJumping = true;
            player_Manager.rb2D.velocity = new Vector2(JumpForce, JumpForce* 1.2f);
        }

        if (WallRight && move < 0 && jump && !isGrounded && !player_Manager.player_Input.isRightpressed)
        {
            WallJumpRight = true;
            Invoke("EndWallJump", 0.5f);
            Flip();
            isJumping = true;
            player_Manager.rb2D.velocity = new Vector2(-JumpForce , JumpForce * 1.2f);
        }

    }

   

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool GroundCheck()
    {
        float ExtraHeightTest = 1.1f;
            
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(player_Manager.myBoxCollider.bounds.center, player_Manager.myBoxCollider.bounds.size - new Vector3 (0.5f, 1) , 0f, Vector2.down, ExtraHeightTest, platformLayerMask);
        Color rayColor;
        if (raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay((player_Manager.myBoxCollider.bounds.center + new Vector3(0, 1)) + new Vector3(player_Manager.myBoxCollider.bounds.extents.x, 0), Vector2.down * (player_Manager.myBoxCollider.bounds.extents.y + ExtraHeightTest), rayColor);
        Debug.DrawRay((player_Manager.myBoxCollider.bounds.center + new Vector3(0, 1)) - new Vector3(player_Manager.myBoxCollider.bounds.extents.x, 0), Vector2.down * (player_Manager.myBoxCollider.bounds.extents.y + ExtraHeightTest), rayColor);
        Debug.DrawRay((player_Manager.myBoxCollider.bounds.center + new Vector3(0, 1)) - new Vector3(player_Manager.myBoxCollider.bounds.extents.x, player_Manager.myBoxCollider.bounds.extents.y + ExtraHeightTest), Vector2.right * (player_Manager.myBoxCollider.bounds.extents.x * 2), rayColor);



        return raycastHit2D.collider != null;
    }

    private bool WallCheck(out int WallDirection)
    {
        float ExtraDistanceTest = 1.1f;
        RaycastHit2D raycastHit2DLeft = Physics2D.BoxCast(player_Manager.myBoxCollider.bounds.center, player_Manager.myBoxCollider.bounds.size - new Vector3(1, 0), 0f, Vector2.left, ExtraDistanceTest, platformLayerMask);
        RaycastHit2D raycastHit2DRight = Physics2D.BoxCast(player_Manager.myBoxCollider.bounds.center, player_Manager.myBoxCollider.bounds.size - new Vector3(1, 0), 0f, Vector2.right, ExtraDistanceTest, platformLayerMask);
        if (raycastHit2DLeft.collider != null)
        {
            WallDirection = 1; //Left
            return true;
        } else if (raycastHit2DRight.collider != null)
        {
            WallDirection = 2; //Right
            return true;
        }
        else
        {
            WallDirection = 0;
            return false;
        }
        
    }

    private bool RoofCheck()
    {
        float ExtraDistanceTest = 1.1f;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(player_Manager.myBoxCollider.bounds.center, player_Manager.myBoxCollider.bounds.size - new Vector3(0.5f, 1f), 0f, Vector2.up, ExtraDistanceTest, platformLayerMask);
        
        return raycastHit2D.collider != null;

    }

    private void PlayerLanding()
    {
        isLanding = false;
    }

    private void EndWallJump()
    {
        WallJumpRight = false;
        WallJumpLeft = false;
    }

}


