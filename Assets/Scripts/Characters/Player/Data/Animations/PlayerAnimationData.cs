using System;
using UnityEngine;



    [Serializable]
    public class PlayerAnimationData
    {
        [Header("State Group Parameter Names")]
        [SerializeField] private string groundedParameterName = "Grounded";
        [SerializeField] private string movingParameterName = "Moving";
        [SerializeField] private string stoppingParameterName = "Stopping";
        [SerializeField] private string landingParameterName = "Landing";
        [SerializeField] private string airborneParameterName = "Airborne";

        [Header("Grounded Parameter Names")]
        [SerializeField] private string idleParameterName = "isIdling";
        [SerializeField] private string dashParameterName = "isDashing";
        [SerializeField] private string walkParameterName = "isWalking";
        [SerializeField] private string runParameterName = "isRunning";
        [SerializeField] private string sprintParameterName = "isSprinting";
        [SerializeField] private string mediumStopParameterName = "isMediumStopping";
        [SerializeField] private string hardStopParameterName = "isHardStopping";
        [SerializeField] private string rollParameterName = "isRolling";
        [SerializeField] private string hardLandParameterName = "isHardLanding";
        [SerializeField] private string rollLeftParameterName = "RollLeft";
        [SerializeField] private string rollRightParameterName = "RollRight";
        [SerializeField] private string attackParameterName = "Attack";
        [SerializeField] private string comboParameterName = "Combo";
        [SerializeField] private string skill1ParameterName = "Skill1";
        [SerializeField] private string skill2ParameterName = "Skill2";
        [SerializeField] private string ultimateParameterName = "Ultimate";
        [SerializeField] private string getHitParameterName = "GetHit";


    [Header("Airborne Parameter Names")]
        [SerializeField] private string fallParameterName = "isFalling";

        public int GroundedParameterHash { get; private set; }
        public int MovingParameterHash { get; private set; }
        public int StoppingParameterHash { get; private set; }
        public int LandingParameterHash { get; private set; }
        public int AirborneParameterHash { get; private set; }

        public int IdleParameterHash { get; private set; }
        public int DashParameterHash { get; private set; }
        public int WalkParameterHash { get; private set; }
        public int RunParameterHash { get; private set; }
        public int SprintParameterHash { get; private set; }
        public int MediumStopParameterHash { get; private set; }
        public int HardStopParameterHash { get; private set; }
        public int RollParameterHash { get; private set; }
        public int HardLandParameterHash { get; private set; }
        public int FallParameterHash { get; private set; }
        public int RollLeftParameterHash { get; private set; }
        public int RollRightParameterHash { get; private set; }
        public int Attack { get; private set; }
        public int Combo { get; private set; }
        public int Skill1 { get; private set; }
        public int Skill2 { get; private set; }
        public int Ultimate { get; private set; }
        public int GetHit { get; private set; }


    public void Initialize()
        {
            GroundedParameterHash = Animator.StringToHash(groundedParameterName);
            MovingParameterHash = Animator.StringToHash(movingParameterName);
            StoppingParameterHash = Animator.StringToHash(stoppingParameterName);
            LandingParameterHash = Animator.StringToHash(landingParameterName);
            AirborneParameterHash = Animator.StringToHash(airborneParameterName);

            IdleParameterHash = Animator.StringToHash(idleParameterName);
            DashParameterHash = Animator.StringToHash(dashParameterName);
            WalkParameterHash = Animator.StringToHash(walkParameterName);
            RunParameterHash = Animator.StringToHash(runParameterName);
            SprintParameterHash = Animator.StringToHash(sprintParameterName);
            MediumStopParameterHash = Animator.StringToHash(mediumStopParameterName);
            HardStopParameterHash = Animator.StringToHash(hardStopParameterName);
            RollParameterHash = Animator.StringToHash(rollParameterName);
            HardLandParameterHash = Animator.StringToHash(hardLandParameterName);
            FallParameterHash = Animator.StringToHash(fallParameterName);
            RollLeftParameterHash = Animator.StringToHash(rollLeftParameterName);
            RollRightParameterHash = Animator.StringToHash(rollRightParameterName);
            Attack = Animator.StringToHash(attackParameterName);
            Combo = Animator.StringToHash(comboParameterName);
            Skill1 = Animator.StringToHash(skill1ParameterName);
            Skill2 = Animator.StringToHash(skill2ParameterName);
            Ultimate = Animator.StringToHash(ultimateParameterName);
            GetHit = Animator.StringToHash(getHitParameterName);

    }
}
