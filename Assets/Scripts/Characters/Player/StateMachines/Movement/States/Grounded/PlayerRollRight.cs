using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerRollRight : PlayerGroundedState
{
    public PlayerRollRight(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.ReusableData.MovementDecelerationForce = groundedData.StopData.HardDecelerationForce;

        StartAnimation(stateMachine.Player.AnimationData.RollRightParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.RollRightParameterHash);

    }
    public override void OnAnimationExitEvent()
    {


        stateMachine.ChangeState(stateMachine.RunningState);

    }

}