using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill2State : PlayerAttackState
{
    public PlayerSkill2State(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.Combo);

    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.Combo);

    }
}
