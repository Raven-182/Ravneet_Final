using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekState : FSMBaseState
{
    private SeekBehaviour seekBehaviour;
    private Vector3 origin;

    public override void Init(GameObject _owner, FSM _fsm)
    {
        base.Init(_owner, _fsm);
        seekBehaviour = owner.GetComponent<SeekBehaviour>();
        origin = owner.transform.position; // Set origin
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Entering SeekState");
        seekBehaviour.SetTarget(origin);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (seekBehaviour.HasReachedDestination())
        {
            Debug.Log("Reached origin, switching to WanderState");
            fsm.ChangeState("WanderState");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exiting SeekState");
    }
}
