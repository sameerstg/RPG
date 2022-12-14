using UnityEngine;
using UnityEngine.InputSystem;


    public class PlayerSprintingState : PlayerMovingState
    {
        private float startTime;

        private bool keepSprinting;
        private bool shouldResetSprintState;

        public PlayerSprintingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void Enter()
        {
            stateMachine.ReusableData.MovementSpeedModifier = abilities.agility.value;

            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.SprintParameterHash);

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.StrongForce;

            startTime = Time.time;

            shouldResetSprintState = true;

            if (!stateMachine.ReusableData.ShouldSprint)
            {
                keepSprinting = false;
            }
        }

        public override void Exit()
        {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.SprintParameterHash);

            if (shouldResetSprintState)
            {
                keepSprinting = false;

                stateMachine.ReusableData.ShouldSprint = false;
            }
        }

        public override void Update()
        {
            base.Update();

            if (keepSprinting)
            {
                return;
            }

            if (Time.time < startTime + groundedData.SprintData.SprintToRunTime)
            {
                return;
            }

            StopSprinting();
        }

        private void StopSprinting()
        {
            if (stateMachine.ReusableData.MovementInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.IdlingState);

                return;
            }

            stateMachine.ChangeState(stateMachine.RunningState);
        }

        protected override void AddInputActionsCallbacks()
        {
            base.AddInputActionsCallbacks();

        stateMachine.Player.Input.PlayerActions.Dash.started += OnDashRollStart;
            stateMachine.Player.Input.PlayerActions.Sprint.performed += OnSprintPerformed;

    }

    protected override void RemoveInputActionsCallbacks()
        {
            base.RemoveInputActionsCallbacks();

        stateMachine.Player.Input.PlayerActions.Dash.started -= OnDashRollStart;
            stateMachine.Player.Input.PlayerActions.Sprint.performed -= OnSprintPerformed;

    }
    private void OnDashRollStart(InputAction.CallbackContext obj)
    {
/*        if (stateMachine.ReusableData.MovementInput.x == 0)
        {
            OnDashStarted(obj);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.RollLeft);
        }
*/    }


    private void OnSprintPerformed(InputAction.CallbackContext context)
        {
            keepSprinting = true;

            stateMachine.ReusableData.ShouldSprint = true;
        }

        protected override void OnMovementCanceled(InputAction.CallbackContext context)
        {
            stateMachine.ChangeState(stateMachine.HardStoppingState);

            base.OnMovementCanceled(context);
        }


        protected override void OnFall()
        {
            shouldResetSprintState = false;

            base.OnFall();
        }
   
}