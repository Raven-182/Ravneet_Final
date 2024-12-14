using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3CheeringState : FSMBaseState
{
    private Transform player;
    private float cheeringTime = 5f;
    private float cheeringTimer = 0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cheeringTimer = 0f;
        if (botAnimator != null)
        {
            botAnimator.SetTrigger("Cheer");
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cheeringTimer += Time.deltaTime;

        if (cheeringTimer >= cheeringTime)
        {
            fsm.ChangeState("PatrolState");
        }
    }
}
