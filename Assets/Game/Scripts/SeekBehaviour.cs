using UnityEngine;

public class SeekBehaviour : MonoBehaviour
{
    private Animator animator;
    private Vector3 target;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTarget(Vector3 seekTarget)
    {
        target = seekTarget;
    }

    private void Update()
    {
        MoveToTarget(target);
    }

private void MoveToTarget(Vector3 target)
{
    Vector3 direction = (target - transform.position).normalized;
    direction.y = 0; // Ignore vertical movement

    // Rotate character to face the movement direction
    if (direction != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Smooth rotation
    }

    // Set Animator parameters
    if (Vector3.Distance(transform.position, target) > 0.5f)
    {
        animator.SetFloat("Speed", 1f); // Set speed for movement animation
    }
    else
    {
        animator.SetFloat("Speed", 0f); 
    }
}


    public bool HasReachedDestination()
    {
        return Vector3.Distance(transform.position, target) <= 1.0f;
    }
}
