using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerRollLeft : PlayerGroundedState
{
    public PlayerRollLeft(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ResetVelocity();
        stateMachine.Player.Animator.applyRootMotion = true;
        StartAnimation(stateMachine.Player.AnimationData.RollLeftParameterHash);
    }
    public override void Update()
    {
        
    }
    public override void PhysicsUpdate()
    {
        
    }
    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.Animator.applyRootMotion = false;

        StopAnimation(stateMachine.Player.AnimationData.RollLeftParameterHash);

    }   
    public override void OnAnimationExitEvent() {


        stateMachine.ChangeState(stateMachine.RunningState);

    }

}
