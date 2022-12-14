using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineImplementation
{
    internal Enemy enemy;
    public StateMachineImplementation(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public  abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract void OnTriggerEnter(Collider collider);
    public abstract void OnTriggerExit(Collider collider);
    public abstract void OnAnimationEnterEvent();
    public abstract void OnAnimationExitEvent();
    public abstract void OnAnimationTransitionEvent();

}
