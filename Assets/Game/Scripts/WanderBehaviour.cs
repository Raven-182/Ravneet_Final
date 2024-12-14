using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WanderBehaviour : MonoBehaviour
{
    public float wanderRadius = 10f; 
    public float wanderInterval = 3f; 

    private Animator animator;
    private Vector3 wanderTarget;
    private float timer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        wanderTarget = transform.position; 
    }

    private void Update()
    {
        timer += Time.deltaTime;


        if (timer >= wanderInterval)
        {
            wanderTarget = GetRandomPointWithinRadius(transform.position, wanderRadius);
            timer = 0f;
        }

        // Move toward the target
        MoveToTarget(wanderTarget);
    }

private void MoveToTarget(Vector3 target)
{
    Vector3 direction = (target - transform.position).normalized;
    direction.y = 0; 


    if (direction != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Smooth rotation
    }


    if (Vector3.Distance(transform.position, target) > 0.5f)
    {
        animator.SetFloat("Speed", 1f); 
    }
    else
    {
        animator.SetFloat("Speed", 0f); 
    }
}


    private Vector3 GetRandomPointWithinRadius(Vector3 center, float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float distance = Random.Range(0f, radius);
        float x = center.x + Mathf.Cos(angle) * distance;
        float z = center.z + Mathf.Sin(angle) * distance;
        return new Vector3(x, center.y, z);
    }
}
