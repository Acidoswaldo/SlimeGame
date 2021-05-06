using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Player_Manager player_Manager;
    Player_Input MyPlayerInput;
    Player_Attack MyPlayerAttack;
    BoxCollider2D MyBoxCollider2D;
    Rigidbody2D MyRigidbody2D;

    
    [SerializeField] private LayerMask platformLayerMask;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    float GroundCheckLastCall = 0f;
    float WallCheckLastCall = 0f;

    public bool IsOnWallRight;
    public bool IsOnWallLeft;

    

    bool walljumpLeft;
    bool walljumpRight;


    bool CanMove = true;
    bool CanJump = true;
    bool CanDash = true;
  

    public bool IsGrounded;
    public bool IsJumping;
    public bool IsLanding;

    float landingTime = 0.6f;

    bool IsinAir;
   
    public bool m_FacingRight = true;
    private float JumpBoostTimer;
    private float JumpboostMaxTime = 0.35f;
    [SerializeField] float JumpForce = 400;
    [SerializeField] float moveSpeed = 10;

    public bool IsDashing = false;
    private float DashSpeed = 50;
    private float DashTime;
    [SerializeField]
    private float DashDuration = 0.83f;
    private float DashCooldown;
    private float DashMaxCooldown = 2; 





    void Start()
    {
        player_Manager = gameObject.GetComponent<Player_Manager>();
        MyPlayerInput = player_Manager.getPlayer_Input();
        MyBoxCollider2D = player_Manager.getBoxCollider2D();
        MyRigidbody2D = player_Manager.getRigidbody2D();
        MyPlayerAttack = player_Manager.getPlayer_Attack();

    }

    private void Update()
    {
       


        // Check Ground

        if (Time.time - GroundCheckLastCall >= 0.2f)
        {
            if (GroundCheck())
            {
                walljumpRight = false;
                walljumpLeft = false;
                IsGrounded = true;
                if (IsinAir == true)
                {
                    IsinAir = false;
                    IsLanding = true;
                    CanJump = false;
                    Invoke("FinishLanding", landingTime);
                    Invoke("AllowJumping", landingTime/2);
                }
            }
            else
            {
                IsGrounded = false;
            }
            GroundCheckLastCall = Time.time;
        }


        // Check Walls
        if (Time.time - WallCheckLastCall >= 0.2f)
        {
            if ((!walljumpLeft || !walljumpRight) && (!walljumpLeft || !walljumpRight))
            {
                int WallDirection;
                if (WallCheck(out WallDirection))
                {
                    if (WallDirection == 1) // left
                    {

                        if (m_FacingRight)
                        {
                            Flip();
                        }
                        if (IsinAir)
                        {
                            IsinAir = false;
                            CanMove = false;
                            CanJump = false;
                            Invoke("AllowMovement", 0.5f);
                            Invoke("AllowJumping", 0.2f);
                        }
                        IsOnWallLeft = true;
                        IsOnWallRight = false;
                    }
                    else if (WallDirection == 2) //right
                    {

                        if (!m_FacingRight)
                        {
                            Flip();
                        }
                        if (IsinAir)
                        {
                            IsinAir = false;
                            CanMove = false;
                            CanJump = false;
                            Invoke("AllowMovement", 0.5f);
                            Invoke("AllowJumping", 0.2f);
                        }
                        IsOnWallRight = true;
                        IsOnWallLeft = false;
                    }
                }
                else
                {
                    IsOnWallLeft = false;
                    IsOnWallRight = false;
                }
            }

            WallCheckLastCall = Time.time;
        }

        //Conditions

        if (MyRigidbody2D.velocity.y <= 0)
        {
            IsJumping = false;
        }


        if ((IsOnWallLeft || IsOnWallRight) && !IsGrounded)
        {
            MyRigidbody2D.drag = 20;
        }
        else
        {
            MyRigidbody2D.drag = 0;
        }

        // dash
        // Dash Time
        if (IsDashing)
        {
            if(DashTime > 0)
            {
                DashTime -= Time.deltaTime;
            }
            else
            {
                MyRigidbody2D.velocity = Vector3.zero;
                CanMove = true;
                CanJump = true;
                IsDashing = false;
              
            }
        }

        // Dash cooldown
        if (!CanDash)
        {
            if(DashCooldown > 0)
            {
                DashCooldown -= Time.deltaTime;
            }
            else
            {
                CanDash = true;
            }

        }




    }


    private void FixedUpdate()
    {
        // Check if is attacking
        if (!MyPlayerAttack.IsAttacking)
        {
            // Check input and move

            // jumping

            if (MyPlayerInput.JumpPressed)
            {
                movePlayer(0, true);
            }
            if (IsGrounded == true)
            {
                IsJumping = false;
            }




            // directional Movement

            // can't move if it's dashing
            if (MyPlayerInput.DashPressed && !IsDashing)
            {
                if (CanDash)
                {
                    // DashRight
                    if (MyPlayerInput.isRightPressed && !IsOnWallRight)
                    {
                        movePlayer(0, false, true, 1);
                        DashTime = DashDuration;
                        DashCooldown = DashMaxCooldown;
                        IsDashing = true;
                        CanMove = false;
                        CanJump = false;
                        CanDash = false;
                        if (!m_FacingRight)
                        {
                            Flip();
                        }
                    }
                    // DashLeft
                    if (MyPlayerInput.isLeftPressed && !IsOnWallLeft)
                    {
                        movePlayer(0, false, true, 2);
                        DashTime = DashDuration;
                        DashCooldown = DashMaxCooldown;
                        IsDashing = true;
                        CanMove = false;
                        CanJump = false;
                        CanDash = false;
                        if (m_FacingRight)
                        {
                            Flip();
                        }
                    }
                    // DashUp
                    if (MyPlayerInput.isUpPressed)
                    {
                        movePlayer(0, false, true, 3);
                        DashTime = DashDuration / 2;
                        DashCooldown = DashMaxCooldown;
                        IsDashing = true;
                        CanMove = false;
                        CanJump = false;
                        CanDash = false;
                    }
                    //DashDown
                    if (MyPlayerInput.isDownPressed && !IsGrounded)
                    {
                        movePlayer(0, false, true, 4);
                        DashTime = DashDuration;
                        DashCooldown = DashMaxCooldown;
                        IsDashing = true;
                        CanMove = false;
                        CanJump = false;
                        CanDash = false;
                    }
                }
            }
            else
            {
                // Left

                if (MyPlayerInput.isRightPressed && !IsOnWallRight && !walljumpRight && CanMove)
                {
                    movePlayer(1, false);
                    if (!m_FacingRight)
                    {
                        Flip();
                    }
                    if (IsOnWallLeft)
                    {
                        IsOnWallLeft = false;
                        IsinAir = true;
                    }
                }

                //Right

                else if (MyPlayerInput.isLeftPressed && !IsOnWallLeft && !walljumpLeft && CanMove)
                {
                    movePlayer(-1, false);
                    if (m_FacingRight)
                    {
                        Flip();
                    }

                    if (IsOnWallRight)
                    {
                        IsOnWallRight = false;
                        IsinAir = true;
                    }
                }
            }

        }
    }



    public void movePlayer(float move, bool jump = false, bool Dash = false, int DashDirection = 0)
    {
        if (!Dash)
        {
            Vector3 targetVelocity;
            if (IsGrounded)
            {
                targetVelocity = new Vector2((move * moveSpeed) * 10f, MyRigidbody2D.velocity.y);
            }
            else
            {
                targetVelocity = new Vector2((move * moveSpeed) * 8f, MyRigidbody2D.velocity.y);
            }
            MyRigidbody2D.velocity = Vector3.SmoothDamp(MyRigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (IsGrounded && jump && !IsJumping && CanJump)
            {
                IsGrounded = false;

                MyRigidbody2D.velocity = new Vector3(MyRigidbody2D.velocity.x, 0);
                MyRigidbody2D.AddForce(new Vector2(0f, JumpForce));
                IsJumping = true;
                IsinAir = true;
                JumpBoostTimer = JumpboostMaxTime;
            }
            if (IsJumping && jump && !IsGrounded)
            {
                if (JumpBoostTimer > 0)
                {
                    MyRigidbody2D.AddForce(new Vector2(0f, 6));
                    JumpBoostTimer -= Time.deltaTime;
                }
                else
                {
                    IsJumping = false;
                }
            }
            if ((IsOnWallLeft || IsOnWallRight) && jump && !IsGrounded && !IsJumping && CanJump)
            {
                if (IsOnWallLeft)
                {

                    IsOnWallLeft = false;
                    MyRigidbody2D.drag = 0;
                    Flip();
                    MyRigidbody2D.AddForce(new Vector2(JumpForce * 2, JumpForce));
                    //MyRigidbody2D.velocity = new Vector3(10, 5);
                    walljumpLeft = true;
                    IsinAir = true;
                    Invoke("FinishWallJump", 0.5f);
                    JumpBoostTimer = JumpboostMaxTime;


                }
                if (IsOnWallRight)
                {
                    IsOnWallRight = false;
                    MyRigidbody2D.drag = 0;
                    Flip();
                    MyRigidbody2D.AddForce(new Vector2(-JumpForce * 2, JumpForce));
                    //MyRigidbody2D.velocity = new Vector3(-10, 5);
                    walljumpRight = true;
                    IsinAir = true;
                    Invoke("FinishWallJump", 0.5f);
                    JumpBoostTimer = JumpboostMaxTime;

                }
            }
        }
        else
        {
            if (DashDirection == 0)
            {
                return;
            }
            else if (DashDirection == 1) // right
            {
                MyRigidbody2D.velocity = Vector3.zero;
                MyRigidbody2D.velocity = new Vector3(DashSpeed, 0);

            }
            else if (DashDirection == 2) // left
            {
                MyRigidbody2D.velocity = Vector3.zero;
                MyRigidbody2D.velocity = new Vector3(-DashSpeed, 0);
     
            }
            else if (DashDirection == 3) // up
            {
               
                MyRigidbody2D.velocity = Vector3.zero;
                MyRigidbody2D.velocity = new Vector3(0, DashSpeed);
     
            }
            else if (DashDirection == 4) // down
            {
                MyRigidbody2D.velocity = Vector3.zero;
                MyRigidbody2D.velocity = new Vector3(0, -DashSpeed);
         
            }

        }

    }

    void FinishLanding()
    {
        IsLanding = false;
    }

    void FinishWallJump()
    {
        walljumpLeft = false;
        walljumpRight = false;
    }

    // Ground Checks and gizmos

   
    bool GroundCheck()
    {
        float ExtraHeightTest = 0.1f;

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(MyBoxCollider2D.bounds.center, MyBoxCollider2D.bounds.size - new Vector3(0.5f, 0), 0f, Vector2.down, ExtraHeightTest, platformLayerMask);
        DrawGroundGizmo(raycastHit2D, ExtraHeightTest);
        return raycastHit2D.collider != null;
    }

    void DrawGroundGizmo(RaycastHit2D raycastHit2D, float ExtraHeightTest)
    {
        Color rayColor;
        if (raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay((MyBoxCollider2D.bounds.center ) + new Vector3(MyBoxCollider2D.bounds.extents.x, 0), Vector2.down * (MyBoxCollider2D.bounds.extents.y + ExtraHeightTest), rayColor);
        Debug.DrawRay((MyBoxCollider2D.bounds.center ) - new Vector3(MyBoxCollider2D.bounds.extents.x, 0), Vector2.down * (MyBoxCollider2D.bounds.extents.y + ExtraHeightTest), rayColor);
        Debug.DrawRay((MyBoxCollider2D.bounds.center ) - new Vector3(MyBoxCollider2D.bounds.extents.x, MyBoxCollider2D.bounds.extents.y + ExtraHeightTest), Vector2.right * (MyBoxCollider2D.bounds.extents.x * 2), rayColor);

    }

    // Wall Checks and gizmos


    bool WallCheck(out int WallDirection)
    {
        float ExtraDistanceTest = 0.2f;
        RaycastHit2D raycastHit2DLeft = Physics2D.BoxCast(MyBoxCollider2D.bounds.center, MyBoxCollider2D.bounds.size - new Vector3(0.2f, 0), 0f, Vector2.left, ExtraDistanceTest, platformLayerMask);
        RaycastHit2D raycastHit2DRight = Physics2D.BoxCast(MyBoxCollider2D.bounds.center, MyBoxCollider2D.bounds.size - new Vector3(0.2f, 0), 0f, Vector2.right, ExtraDistanceTest, platformLayerMask);
        if (raycastHit2DLeft.collider != null)
        {
            WallDirection = 1; //Left
            DrawWallsGizmo(raycastHit2DLeft, ExtraDistanceTest, WallDirection);
            return true;
        }
        else if (raycastHit2DRight.collider != null)
        {
            WallDirection = 2; //Right
            DrawWallsGizmo(raycastHit2DRight, ExtraDistanceTest, WallDirection);
            return true;
        }
        else
        {
            WallDirection = 0;
            return false;
        }
    }

    void DrawWallsGizmo(RaycastHit2D raycastHit2D, float ExtraHeightTest, int Direction)
    {
        Color rayColor;
        if (raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        if (Direction == 1)
        {
            Debug.DrawRay((MyBoxCollider2D.bounds.center) + new Vector3(0, MyBoxCollider2D.bounds.extents.y), Vector2.left * (MyBoxCollider2D.bounds.extents.x + ExtraHeightTest), rayColor);
            Debug.DrawRay((MyBoxCollider2D.bounds.center) - new Vector3(0, MyBoxCollider2D.bounds.extents.y), Vector2.left * (MyBoxCollider2D.bounds.extents.x + ExtraHeightTest), rayColor);
            Debug.DrawRay((MyBoxCollider2D.bounds.center) - new Vector3(MyBoxCollider2D.bounds.extents.x + ExtraHeightTest, MyBoxCollider2D.bounds.extents.y ), Vector2.up * (MyBoxCollider2D.bounds.extents.y * 2), rayColor);
        }
        if (Direction == 2)
        {
            Debug.DrawRay((MyBoxCollider2D.bounds.center) + new Vector3(0, MyBoxCollider2D.bounds.extents.y), Vector2.right * (MyBoxCollider2D.bounds.extents.x + ExtraHeightTest), rayColor);
            Debug.DrawRay((MyBoxCollider2D.bounds.center) - new Vector3(0, MyBoxCollider2D.bounds.extents.y), Vector2.right * (MyBoxCollider2D.bounds.extents.x + ExtraHeightTest), rayColor);
            Debug.DrawRay((MyBoxCollider2D.bounds.center) + new Vector3(MyBoxCollider2D.bounds.extents.x + ExtraHeightTest, MyBoxCollider2D.bounds.extents.y), Vector2.down * (MyBoxCollider2D.bounds.extents.y * 2), rayColor);
        }

    }


    //Flip Character based on movement

    public void Flip()
    {
              // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void AllowMovement()
    {
        CanMove = true;
    }
    void AllowJumping()
    {
        CanJump = true;
    }
    void AllowDashing()
    {
        CanDash = true;
    }
}
