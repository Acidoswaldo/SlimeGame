using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Player_Manager MyPlayerManager;
    Player_Input MyPlayerInput;
    Player_Movement MyPlayerMovement;
    Rigidbody2D MyRigidobody2D;
    
    public bool IsAttacking = false;
    bool CanAttack = true;

    [SerializeField] float AttackRange;
    [SerializeField] float AttackSpeed;
    float AttackTime;
    public int AttackDirection;

    [SerializeField] GameObject AttackEffectObject;

    private void Start()
    {
        MyPlayerManager = gameObject.GetComponent<Player_Manager>();
        MyPlayerInput = MyPlayerManager.getPlayer_Input();
        MyPlayerMovement = MyPlayerManager.getPlayer_Movement();
        MyRigidobody2D = MyPlayerManager.getRigidbody2D();

       
    }
    // Update is called once per frame
    void Update()
    {

        if (MyPlayerInput.IsLightAttacking && !IsAttacking && CanAttack)
        {
            if((checkDirection() == 1) && !MyPlayerMovement.IsOnWallRight) // right
            {
                if (!MyPlayerMovement.m_FacingRight)
                {
                    MyPlayerMovement.Flip();
                }
                AttackEffectObject.transform.position = gameObject.transform.position + new Vector3(AttackRange, 0);
                AttackEffectObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                AttackEffectObject.transform.localScale = new Vector3(1, 1, 1);
                AttackEffectObject.SetActive(true);
                IsAttacking = true;
                AttackTime = AttackSpeed;
                AttackDirection = 1;

                if (MyPlayerInput.isRightPressed)
                {
                    MyRigidobody2D.AddForce(new Vector3 (40, 0));
                }
            }
             else if ((checkDirection() == 2) && !MyPlayerMovement.IsOnWallLeft) // left
            {
                if (MyPlayerMovement.m_FacingRight)
                {
                    MyPlayerMovement.Flip();
                }
                AttackEffectObject.transform.position = gameObject.transform.position + new Vector3(-AttackRange, 0);
                AttackEffectObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                AttackEffectObject.transform.localScale = new Vector3(1, 1, 1);
                AttackEffectObject.SetActive(true);
                IsAttacking = true;
                AttackTime = AttackSpeed;
               
                AttackDirection = 2;

                if (MyPlayerInput.isLeftPressed)
                {
                    MyRigidobody2D.AddForce(new Vector3(-40, 0));
                }
            }
            else if (checkDirection() == 3) // up
            {
                AttackEffectObject.transform.position = gameObject.transform.position + new Vector3(0, AttackRange);
                AttackEffectObject.transform.localRotation = Quaternion.Euler(0, 0, 90);
                AttackEffectObject.SetActive(true);
                IsAttacking = true;
                AttackDirection = 3;
                AttackTime = AttackSpeed;
            }
            else if ((checkDirection() == 4) && !MyPlayerMovement.IsGrounded) // down
            {
                AttackEffectObject.transform.position = gameObject.transform.position + new Vector3(0, -AttackRange);
                AttackEffectObject.transform.localRotation = Quaternion.Euler(0, 0, 270);
                AttackEffectObject.SetActive(true);
                IsAttacking = true;
                AttackDirection = 4;
                AttackTime = AttackSpeed;

            }
        }

        if (IsAttacking == true)
        {
            if(AttackTime > 0)
            {
                AttackTime -= Time.deltaTime;
            }
            else
            {
                AttackEffectObject.SetActive(false);
                IsAttacking = false;
            }
        }
    }

    public int checkDirection()
    {
        int direction;
        if (MyPlayerInput.isRightPressed)
        {
            direction = 1; // right
        }
        else if (MyPlayerInput.isLeftPressed)
        {
            direction = 2; // left
        }
        else if (MyPlayerInput.isUpPressed)
        {
            direction = 3; // up
        }
        else if (MyPlayerInput.isDownPressed)
        {
            direction = 4; // down
        }
        else
        {
            if (gameObject.transform.localScale.x > 0) // Right
            {
                direction = 1;
            }
            else
            {
                direction = 2;
            }
        }

        return direction;
    }
}
