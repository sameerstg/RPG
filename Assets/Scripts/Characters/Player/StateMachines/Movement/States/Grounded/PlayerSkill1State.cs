using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill1State : PlayerAttackState
{
    public PlayerSkill1State(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.Skill1);

    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.Skill1);

    }
}
