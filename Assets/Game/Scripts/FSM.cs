using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    
    public RuntimeAnimatorController FSMController;
    public Animator fsmAnimator { get; private set;}

    private void Awake(){
        GameObject FSMGo = new GameObject("FSM", typeof(Animator));
        FSMGo.transform.parent = transform;

        fsmAnimator = FSMGo.GetComponent<Animator>();
        fsmAnimator.runtimeAnimatorController = FSMController;

        FSMBaseState[] behaviours = fsmAnimator.GetBehaviours<FSMBaseState>();
        foreach(var behaviour in behaviours){
            behaviour.Init(gameObject,  this);
        }

    }

    public bool ChangeState(string hashStateName){
        bool hasState = fsmAnimator.HasState(0, Animator.StringToHash(hashStateName));
        fsmAnimator.CrossFade(hashStateName, 0.0f, 0);
        return hasState;
    }
}
