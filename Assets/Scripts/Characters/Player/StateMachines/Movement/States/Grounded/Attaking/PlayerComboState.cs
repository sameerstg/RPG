using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComboState : PlayerAttackState
{
    int multiplier;
    public PlayerComboState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {

    }
    public override void Enter()
    {
        AddInputActionsCallbacks();
        base.Enter();
        multiplier = 0;
        StartAnimation(stateMachine.Player.AnimationData.Combo);

    }
    public override void Exit()
    {
        RemoveInputActionsCallbacks();
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.Combo);

    }
  
    protected override void AddInputActionsCallbacks()
    {

        
        stateMachine.Player.Input.PlayerActions.Dash.started += OnDashStarted;
        stateMachine.Player.Input.PlayerActions.Combo.started += OnComboStarted;

    }
    protected override void RemoveInputActionsCallbacks()
    {

        stateMachine.Player.Input.PlayerActions.Dash.started -= OnDashStarted;
        stateMachine.Player.Input.PlayerActions.Combo.started -= OnComboStarted;
    }
    internal override void OnComboStarted(InputAction.CallbackContext obj)
    {
        permitToBypassAnmationExitEvent = true;
    }
    public override void OnAttackEvent()
    {
        base.OnAttackEvent();
       
        stateMachine.Player.skillEffectGenerator.InstantiateAttack(AttackType.Combo, multiplier);
        multiplier++;
        if (multiplier == 3)
        {
            multiplier = 0;
        }
    }
}
