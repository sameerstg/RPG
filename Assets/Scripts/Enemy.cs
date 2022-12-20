using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    [SerializeField]internal Character character;
    StateMachineImplementation state;
    public AnimationData animationData;
    internal NavMeshAgent agent;
    [SerializeField]internal GameObject player;
    internal BaseState baseState;
    internal IdleState idleState ;
    internal ChasingState chasingState;
    internal AttackingState attackingState;
    internal GetHitState hitState;

    
    
    
    
    internal Animator animator;
    private Slider healthSlider;
    internal Rigidbody rb;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        healthSlider = GetComponentInChildren<Slider>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        baseState = new(this);
        idleState = new(this);
        chasingState = new(this);
        attackingState = new(this);
        baseState.enemy = this;
        SwitchState(idleState);
        character.BalanceAbilities();
        SetHealthSlider();
    }
    
    private void Update()
    {
        state.Update();
    }
    public  void OnAnimationExitEvent()
    {
        state.OnAnimationExitEvent();
    }
    private void OnTriggerEnter(Collider other)
    {
        state.OnTriggerEnter(other);
    }
    internal void SwitchState(StateMachineImplementation state)
    {
        if (this.state != null)
        {
            this.state.Exit();

        }
        this.state = state;
        this.state.Enter();
    }
    internal void GetHit(float hitAmount)
    {
        character.GetHit(hitAmount);
        SetHealthSlider();
    }
    internal void SetHealthSlider()
    {
        healthSlider.value = character.currentAbilities.healthValue.value / character.totalAbilities.healthValue.value;

    }
}
public class BaseState :StateMachineImplementation
{
    

    internal float distanceFromPlayer;

    public BaseState(Enemy enemy) : base(enemy)
    {

    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void OnAnimationEnterEvent()
    {
    }

    public override void OnAnimationExitEvent()
    {
    }

    public override void OnAnimationTransitionEvent()
    {
    }

    public override void OnTriggerEnter(Collider collider)
    {

    }

    public override void OnTriggerExit(Collider collider)
    {
    }
    internal void LookAtPlayer()
    {
        enemy.rb.MoveRotation(Quaternion.Euler(new Vector3(0, GetDirectionAngle(-enemy.transform.position + enemy.player.transform.position), 0)));

    }
    private float GetDirectionAngle(Vector3 direction)
    {
        float directionAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (directionAngle < 0f)
        {
            directionAngle += 360f;
        }

        return directionAngle;
    }
    public override void Update()
    {
        
        distanceFromPlayer = Vector3.Distance(enemy.player.transform.position, enemy.transform.position);
    }
    internal void CheckToAttack()
    {
        if (distanceFromPlayer <= enemy.agent.stoppingDistance)
        {
            enemy.SwitchState(enemy.attackingState);
        }

    }
}
public class IdleState : BaseState
{
    public IdleState(Enemy enemy) : base(enemy)
    {

    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void Update()
    {
        base.Update();
        if (distanceFromPlayer > enemy.agent.stoppingDistance)
        {
            enemy.SwitchState(enemy.chasingState);
        }
        CheckToAttack();

    }
}
public class ChasingState : BaseState
{
    public ChasingState(Enemy enemy) : base(enemy)
    {

    }
    public override void Enter()
    {
        base.Enter();
        enemy.animator.SetBool(enemy.animationData.chasing[0], true);
    }
    public override void Update()
    {
        base.Update();
        LookAtPlayer();
        enemy.agent.SetDestination(enemy.player.transform.position);
        CheckToAttack();
    }
    public override void Exit()
    {
        base.Exit();
        enemy.animator.SetBool(enemy.animationData.chasing[0], false);
    }
}
public class AttackingState : BaseState
{
    public AttackingState(Enemy enemy) : base(enemy)
    {

    }
    public override void Enter()
    {
        base.Enter();
        enemy.animator.SetBool(enemy.animationData.attacking[0], true);
    }
    public override void Update()
    {
        LookAtPlayer();
        base.Update();
    }
    public override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }
    }
    public override void OnAnimationExitEvent()
    {
        base.OnAnimationExitEvent();
        enemy.SwitchState(enemy.idleState);
    }
    public override void Exit()
    {
        base.Exit();
        enemy.animator.SetBool(enemy.animationData.attacking[0], false);
    }

}
[System.Serializable]
public class GetHitState : BaseState
{
    public override void Enter()
    {
        base.Enter();
        enemy.animator.SetBool(enemy.animationData.getingHit[0], true);
    }
    public override void Exit()
    {
        base.Exit();
        enemy.animator.SetBool(enemy.animationData.getingHit[0], false);

    }
    public override void OnAnimationExitEvent()
    {
        base.OnAnimationExitEvent();
        enemy.SwitchState(enemy.idleState);
    }
    public GetHitState(Enemy enemy) : base(enemy)
    {

    }
}


[System.Serializable]
public class AnimationData
{
    [SerializeField] public List<string> chasing;
    [SerializeField] public List<string> attacking;
    [SerializeField] public List<string> getingHit;

}