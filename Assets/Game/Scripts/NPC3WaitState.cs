using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3WaitState : FSMBaseState
{
    private float waitTime = 5f;
    private float waitTimer = 0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTimer = 0f; 
        if (botAnimator != null)
        {
            botAnimator.SetBool("IsWalking", false);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTimer += Time.deltaTime;

        if (waitTimer >= waitTime)
        {
            fsm.ChangeState("PatrolState");
        }
    }
}

