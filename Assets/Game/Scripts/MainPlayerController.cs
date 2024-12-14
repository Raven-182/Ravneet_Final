using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    public float backwards = 0.0f;
    public float angularDampeningTime = 2.0f;
    public float deadZone = 10.0f;

    private CharacterController characterController;
    private Animator animator;

    private void Start(){
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }
    void Update(){
        Vector3 direction = Vector3.zero;
        backwards = 0.0f;

        if (Input. GetKey(KeyCode.W)){
        direction += Camera.main.transform.forward;
        backwards = 1.0f;
        }
        if (Input. GetKey(KeyCode.S)){
        direction -= Camera.main.transform.forward;
        backwards = -1.0f;
        }
        if (Input.GetKey(KeyCode.A)) direction -= Camera.main.transform.right; 
        if (Input.GetKey(KeyCode.D)) direction += Camera.main.transform.right;
    
        direction.y = 0.0f;
        direction.Normalize();
    
        direction *= speed;
        animator.SetFloat("Speed", direction.magnitude);
        float angle = Vector3. Angle(transform.forward, direction);
        if (backwards > -1.0F)
        {
            if (Mathf.Abs(angle) <= deadZone){
                transform.LookAt(transform.position + direction);
            }
            else{
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.LookRotation(direction),
                    Time.deltaTime * angularDampeningTime);
            }
        }
    }
private void OnAnimatorMove(){
    Vector3 animationVelocity = animator.deltaPosition / Time.deltaTime;
    characterController.Move((transform.forward * animationVelocity.magnitude * backwards) * Time.deltaTime);

}
}
