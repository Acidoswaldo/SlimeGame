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

  

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;


    private void FixedUpdate()
    {
        if (player_Manager.player_Input.isRightpressed && isGrounded)
        {
            MoveCharacter(speed, false);
           

        } else if (player_Manager.player_Input.isRightpressed && !isGrounded)
        {
            MoveCharacter(speed / 2, false);
            
        }
        else if (player_Manager.player_Input.isLeftpressed && isGrounded)
        {
            MoveCharacter(-speed, false);
          

        } else if (player_Manager.player_Input.isLeftpressed && !isGrounded)
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
        
    }

    public void MoveCharacter(float move, bool jump)
    {
        // Move

        Vector3 targetVelocity = new Vector2(move * 10f, player_Manager.rb2D.velocity.y);
        player_Manager.rb2D.velocity = Vector3.SmoothDamp(player_Manager.rb2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (move > 0 && !m_FacingRight)
        { 
            Flip();
        }
       
        else if (move < 0 && m_FacingRight)
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
        if (isJumping && jump)
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
        float ExtraHeightTest = 0.1f;
            
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(player_Manager.myBoxCollider.bounds.center, player_Manager.myBoxCollider.bounds.size , 0f, Vector2.down, ExtraHeightTest, platformLayerMask);
        Color rayColor;
        if (raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(player_Manager.myBoxCollider.bounds.center + new Vector3(player_Manager.myBoxCollider.bounds.extents.x, 0), Vector2.down * (player_Manager.myBoxCollider.bounds.extents.y + ExtraHeightTest), rayColor);
        Debug.DrawRay(player_Manager.myBoxCollider.bounds.center - new Vector3(player_Manager.myBoxCollider.bounds.extents.x, 0), Vector2.down * (player_Manager.myBoxCollider.bounds.extents.y + ExtraHeightTest), rayColor);
        Debug.DrawRay(player_Manager.myBoxCollider.bounds.center - new Vector3(player_Manager.myBoxCollider.bounds.extents.x, player_Manager.myBoxCollider.bounds.extents.y + ExtraHeightTest), Vector2.right * (player_Manager.myBoxCollider.bounds.extents.x), rayColor);



        return raycastHit2D.collider != null;
    }

    private void PlayerLanding()
    {
        isLanding = false;
    }

}


