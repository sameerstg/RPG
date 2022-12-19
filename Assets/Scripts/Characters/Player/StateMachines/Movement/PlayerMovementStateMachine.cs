
    public class PlayerMovementStateMachine : StateMachine
    {
        public Player Player { get; }
        internal Abiblities abilites;
        public PlayerStateReusableData ReusableData { get; }

        public PlayerIdlingState IdlingState { get; }
        public PlayerDashingState DashingState { get; }
        public PlayerRollLeft RollLeft { get; }
    public PlayerRollRight RollRight { get; }

    public PlayerWalkingState WalkingState { get; }
        public PlayerRunningState RunningState { get; }
        public PlayerSprintingState SprintingState { get; }

        public PlayerLightStoppingState LightStoppingState { get; }
        public PlayerMediumStoppingState MediumStoppingState { get; }
        public PlayerHardStoppingState HardStoppingState { get; }

        public PlayerLightLandingState LightLandingState { get; }
        public PlayerRollingState RollingState { get; }
        public PlayerHardLandingState HardLandingState { get; }

        public PlayerJumpingState JumpingState { get; }
        public PlayerFallingState FallingState { get; }
        public PlayerAttackState AttackState { get; }
        public PlayerComboState ComboState { get; }
        public PlayerSkill1State Skill1State { get; }
        public PlayerSkill2State Skill2State { get; }
        public PlayerUltimateState UltimateState { get; }

        public PlayerMovementStateMachine(Player player)
        {
            Player = player;
            ReusableData = new PlayerStateReusableData();
        abilites = player.Data.abilities;
            IdlingState = new PlayerIdlingState(this);
            DashingState = new PlayerDashingState(this);

            WalkingState = new PlayerWalkingState(this);
            RunningState = new PlayerRunningState(this);
            SprintingState = new PlayerSprintingState(this);

            LightStoppingState = new PlayerLightStoppingState(this);
            MediumStoppingState = new PlayerMediumStoppingState(this);
            HardStoppingState = new PlayerHardStoppingState(this);

            LightLandingState = new PlayerLightLandingState(this);
            RollingState = new PlayerRollingState(this);
            HardLandingState = new PlayerHardLandingState(this);

            JumpingState = new PlayerJumpingState(this);
            FallingState = new PlayerFallingState(this);
            RollLeft = new PlayerRollLeft(this);
            RollRight = new PlayerRollRight(this);
            AttackState = new(this);
            ComboState = new(this);
            Skill1State = new(this);
            Skill2State = new(this);
            UltimateState = new(this);

        }
    }
