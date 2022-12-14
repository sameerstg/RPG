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
        Debug.Log("Rolling state");
        stateMachine.ReusableData.MovementDecelerationForce = groundedData.StopData.HardDecelerationForce;

        StartAnimation(stateMachine.Player.AnimationData.RollLeftParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.RollLeftParameterHash);

    }   
    public override void OnAnimationExitEvent() {


        stateMachine.ChangeState(stateMachine.RunningState);

    }

}
