using UnityEngine;



    public class PlayerAnimationEventTrigger : MonoBehaviour
    {
        private Player player;

        private void Awake()
        {
            //player = transform.parent.GetComponent<Player>();
            player = GetComponent<Player>();
        }

        public void TriggerOnMovementStateAnimationEnterEvent()
        {
            if (IsInAnimationTransition())
            {
                return;
            }

            player.OnMovementStateAnimationEnterEvent();
        }

        public void TriggerOnMovementStateAnimationExitEvent()
        {
        /*if (IsInAnimationTransition())
        {
            return;
        }*/
        //Debug.Log("Animation exit");
            player.OnMovementStateAnimationExitEvent();
        }

        public void TriggerOnMovementStateAnimationTransitionEvent()
        {
            if (IsInAnimationTransition())
            {
                return;
            }

            player.OnMovementStateAnimationTransitionEvent();
        }

        private bool IsInAnimationTransition(int layerIndex = 0)
        {
            return player.Animator.IsInTransition(layerIndex);
        }
    public void Attack()
    {
        
        player.OnAttackEvent();

    }public void Airbone()
    {
        
        player.OnAirboneEvent();

    }public void AirboneExit()
    {
        
        player.OnAirboneExitEvent();

    }public void AirboneTransition()
    {
        
        player.OnAirboneTransitionEvent();

    }
}
