using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskName("Stop Movement")]
[TaskCategory("Generic")]
[TaskDescription("Stops the NavMeshAgent's movement.")]
public class StopMovement : Action
{
    private NavMeshAgent agent;

    public override void OnAwake()
    {
    
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public override TaskStatus OnUpdate()
    {
    
        if (agent != null)
        {
            agent.isStopped = true; // Stop movement
            return TaskStatus.Success; 
        }

        return TaskStatus.Failure; 
    }
}
