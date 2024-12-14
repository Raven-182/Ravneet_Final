using UnityEngine;

public class WanderState : FSMBaseState
{
    private WanderBehaviour wanderBehaviour;
    private Vector3 origin;
    private float maxDistance = 20f;

    public override void Init(GameObject _owner, FSM _fsm)
    {
        base.Init(_owner, _fsm);
        wanderBehaviour = owner.GetComponent<WanderBehaviour>();
        origin = owner.transform.position; 
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Entering WanderState");
        wanderBehaviour.enabled = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceFromOrigin = Vector3.Distance(owner.transform.position, origin);

        if (distanceFromOrigin > maxDistance)
        {
            Debug.Log("Too far from origin, switching to SeekState");
            wanderBehaviour.enabled = false;
            fsm.ChangeState("SeekState");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exiting WanderState");
        wanderBehaviour.enabled = false;
    }
}
