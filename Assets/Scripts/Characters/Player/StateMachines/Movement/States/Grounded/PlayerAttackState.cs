using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerGroundedState
{
    internal bool permitToBypassAnmationExitEvent = false;
    public PlayerAttackState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.Attack);
        stateMachine.ReusableData.MovementSpeedModifier = 0;
        stateMachine.ReusableData.MovementDecelerationForce = groundedData.StopData.HardDecelerationForce;
        stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;
        ResetVelocity();

    }
    public override void Update()
    {
        base.Update();
        LookAtEnemy();
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.Attack);

    }
    public override void OnAnimationExitEvent()
    {
        if (permitToBypassAnmationExitEvent)
        {
            permitToBypassAnmationExitEvent = !permitToBypassAnmationExitEvent;
            return;
        }
        base.OnAnimationExitEvent();
        stateMachine.ChangeState(stateMachine.IdlingState);
    }
}
