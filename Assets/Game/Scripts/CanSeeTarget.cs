using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskName("Can See Target")]
[TaskCategory("Generic")]
[TaskDescription("Returns Success if it can see the target.")]
public class CanSeeTargetCondition : Conditional
{
    public SharedGameObject target;
    public float distance = 10.0f;
    public float angle = 35.0f;

    private float halfAngle;
    private Color handleColor = Color.green;

    public SharedBool isPlayerVisible;
    public SharedInt detectionCounter;

    private bool wasPlayerPreviouslyVisible = false;

    public override void OnStart()
    {
        halfAngle = angle / 2.0f;
    }

    public override TaskStatus OnUpdate()
    {
        if (target.Value != null)
        {
            Vector3 dirToTarget = target.Value.transform.position - transform.position;
            Vector3 dirNormalized = dirToTarget.normalized;
            float magDistance = dirToTarget.magnitude;
            float viewAngle = Vector3.Angle(transform.forward, dirNormalized);

            if (Mathf.Abs(viewAngle) < halfAngle && magDistance <= distance)
            {
                handleColor = Color.red;
                isPlayerVisible.Value = true;

                // Increment counter only if the player was not visible before
                if (!wasPlayerPreviouslyVisible)
                {
                    detectionCounter.Value++;
                    wasPlayerPreviouslyVisible = true;
                }

                return TaskStatus.Success;
            }
        }

        handleColor = Color.green;
        isPlayerVisible.Value = false;
        wasPlayerPreviouslyVisible = false;

        return TaskStatus.Failure;
    }
}
