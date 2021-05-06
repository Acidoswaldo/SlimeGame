using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    Player_Manager player_Manager;
    Player_Input MyPlayerInput;
    internal Animator animator;

    private string currentState;
    string newState;


    public string PLAYER_IDLE = "Player_Idle";
    public string PLAYER_RUN = "Player_Run";
    public string PLAYER_JUMP = "Player_Jump";
    public string PLAYER_FALL = "Player_JumpToFall";
    public string PLAYER_LAND = "Player_Land";
    public string PLAYER_WALL = "Player_Wall";
    public string PLAYER_GLATTTACK = "Player_GLAttack";

    // Start is called before the first frame update
    void Start()
    {
        player_Manager = gameObject.GetComponent<Player_Manager>();
        MyPlayerInput = player_Manager.getPlayer_Input();
        animator = GetComponent<Animator>();
    }

    public void changeState(string StateChange, bool AnimationWait = false, float WaitTime = 0)
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
