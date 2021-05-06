using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    Player_Manager player_Manager;
    Player_Controls Controls;


    // directional input
    public bool isRightPressed;
    public bool isLeftPressed;
    public bool isDownPressed;
    public bool isUpPressed;

    //jump
    public bool JumpPressed;

    //dash
    public bool DashPressed;

    //Attacking
    public bool IsLightAttacking;

    bool CanBasicMove = true;
    bool CanBasicAttack = true;

    private void Awake()
    {
        Controls = new Player_Controls();

        if (CanBasicMove)
        {
            
            Controls.Movement.MoveLeft.performed += ctx => isLeftPressed = true;
            Controls.Movement.MoveLeft.canceled += ctx => isLeftPressed = false;

            Controls.Movement.MoveRight.performed += ctx => isRightPressed = true;
            Controls.Movement.MoveRight.canceled += ctx => isRightPressed = false;

            Controls.Movement.Jump.performed += ctx => JumpPressed = true;
            Controls.Movement.Jump.canceled += ctx => JumpPressed = false;

            Controls.Movement.Down.performed += ctx => isDownPressed = true;
            Controls.Movement.Down.canceled += ctx => isDownPressed = false;

            Controls.Movement.Up.performed += ctx => isUpPressed = true;
            Controls.Movement.Up.canceled += ctx => isUpPressed = false;

            Controls.Movement.Dash.performed += ctx => DashPressed = true;
            Controls.Movement.Dash.canceled += ctx => DashPressed = false;

        }

        if (CanBasicAttack)
        {
            Controls.Attacking.LightAttack.performed += ctx => IsLightAttacking = true;
            Controls.Attacking.LightAttack.canceled += ctx => IsLightAttacking = false;
        }

    }


    void Start()
    {
        player_Manager = gameObject.GetComponent<Player_Manager>();
    }


    void Update()
    {


    }

    private void OnEnable()
    {
        Controls.Movement.Enable();
        Controls.Attacking.Enable();
    }

    private void OnDisable()
    {
        Controls.Movement.Disable();
        Controls.Attacking.Disable();
    }




}


    /*
      
        // (Directional) Check Horizontal Input
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            isRightPressed = true;
        } else
        {
            isRightPressed = false;
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            isLeftPressed = true;
        } else
        {
            isLeftPressed= false;
        }

        // (Directional) Check Vertical Input
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            isUpPressed = true;
        } else
        {
            isUpPressed = false;
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            isDownPressed = true;
        } else
        {
            isDownPressed = false;
        }

        // (Jump) Check Jump Input

       if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
        {
            JumpPressed = true;
        } else
        {
            JumpPressed = false;
        }


    }

    */