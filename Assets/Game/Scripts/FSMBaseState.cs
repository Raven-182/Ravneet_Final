using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FSMBaseState : StateMachineBehaviour
{
    protected FSM fsm {get; private set;}
    protected GameObject owner {get; private set;}
    protected Animator botAnimator { get; private set; }

    public virtual void Init(GameObject _owner, FSM _fsm){

        owner = _owner;
        fsm = _fsm;
             botAnimator = owner.GetComponent<Animator>();
        if (botAnimator == null)
        {
            Debug.Log("Bot Animator not found on owner GameObject!");
        }

    }
}
