using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimateState : PlayerAttackState
{
    Vector3 startPosition;
    public PlayerUltimateState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.Ultimate);
        startPosition = stateMachine.Player.transform.position;
        /*        stateMachine.ReusableData.MovementDecelerationForce = airborneData.JumpData.DecelerationForce;
                stateMachine.Player.Rigidbody.AddForce(Vector3.up * 30, ForceMode.VelocityChange);
        */



    }
    
    public override void OnTriggerExit(Collider collider)
    {
    }
    public override void OnTriggerEnter(Collider collider)
    {
        
    }


    public override void Update()
    {
        base.Update(); 
    }
    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.Ultimate);
        stateMachine.Player.transform.position = startPosition; 

    }
    public override void OnAnimationExitEvent()
    {
        stateMachine.Player.skillEffectGenerator.InstantiateAttack(AttackType.Ultimate, 0);

        base.OnAnimationExitEvent();
    }
}
