
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
[TaskName("NPC Patrol")]
[TaskCategory("Generic")]
[TaskDescription("The NPC will patrol a list of game objects for waypoints")]
public class PatrolAction : Action
{
    private NavMeshAgent agent;
    public SharedGameObjectList waypoints;
    public bool loop = true;
    private int index = 0;
    public override void OnAwake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    public override void OnStart()
    {
        base.OnStart();
        if (index < waypoints.Value.Count)
        {
            agent.isStopped = false;
            agent.SetDestination(waypoints.Value[index].transform.position);
        }
    }
    public override TaskStatus OnUpdate()
    {
        if ((transform.position - agent.destination).magnitude <= agent.stoppingDistance)
        {
            index++;
            if (index >= waypoints.Value.Count && loop)
            {
                index = 0;
            }
            if (index < waypoints.Value.Count)
            {
                agent.SetDestination(waypoints.Value[index].transform.position);
                return TaskStatus.Running;
            }
            else{
                  return TaskStatus.Success;
            }
        }
        
        return TaskStatus.Running;
    }
}
