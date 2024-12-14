using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC3PatrolState : FSMBaseState
{
    private NavMeshAgent agent;
     private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

     public override void Init(GameObject _owner, FSM _fsm)
    {
        base.Init(_owner, _fsm);
        agent = owner.GetComponent<NavMeshAgent>();
        patrolPoints = owner.GetComponent<NPC3Controller>().patrolPoints;

    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("Going to next point");
       
        if (botAnimator != null)
        {
            Debug.Log("In the if statement");
            botAnimator.SetBool("IsWalking", true); // for the idle and walk animationx
        }
        GoToNextPatrolPoint();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // when the agent reaches a destination
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            // If we're at point 2 (when index wraps back to 0) go to wait state
            if (currentPatrolIndex == 0)
            {
                if (botAnimator != null)
                {
                    botAnimator.SetBool("IsWalking", false); 
                }

                fsm.ChangeState("WaitState");
            }
            else
            {
                GoToNextPatrolPoint();
            }
        }
    }

    private void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.destination = patrolPoints[currentPatrolIndex].position;
        //wraps back to 0
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }
}
