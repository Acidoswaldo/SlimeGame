using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animationcontroller2 : MonoBehaviour
{

    [SerializeField] internal Player_Manager2 player_Manager;
    [SerializeField] internal Animator animator;

    private string currentState;
    string newState;
  

    public string PLAYER_IDLE = "Player_Idle";
    public string PLAYER_RUN = "Player_Run";
    public string PLAYER_JUMP = "Player_Jump";
    public string PLAYER_FALL = "Player_JumpToFall";
    public string PLAYER_LAND = "Player_Land";
    public string PLAYER_WALL = "Player_Wall";


    public void changeState(string StateChange, bool AnimationWait, float WaitTime)
    {
        if (currentState == StateChange)
        {
            return;
        }
         if (AnimationWait == true)
        {
            newState = StateChange;
            //float animDelay = animator.GetCurrentAnimatorStateInfo(0).length;
            Invoke("ChangePlayAnimation", WaitTime);
            

        }
        else
        {
            newState = StateChange;
            ChangePlayAnimation();
           
        }
       
    }

    void ChangePlayAnimation()
    {
        animator.Play(newState);
        currentState = newState;
    }

  




}
