using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    StateMachineImplementation state;
    public AnimationData animationData;
    internal NavMeshAgent agent;
    [SerializeField]internal GameObject player;
    internal BaseState baseState;
    internal IdleState idleState ;
    internal ChasingState chasingState;
    internal AttackingState attackingState;
    internal Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        baseState = new(this);
        idleState = new(this);
        chasingState = new(this);
        attackingState = new(this);
        
        baseState.enemy = this;
        SwitchState(idleState);


    }
    private void Start()
    {


    }
    private void Update()
    {
        state.Update();
    }
    public  void OnAnimationExitEvent()
    {
        state.OnAnimationExitEvent();
    }
    internal void SwitchState(StateMachineImplementation state)
    {
        if (this.state != null)
        {
            print(state);
            this.state.Exit();

        }
        this.state = state;
        this.state.Enter();
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
        enemy.transform.LookAt(enemy.player.transform.position);

    }
    public override void Update()
    {
        
        distanceFromPlayer = Vector3.Distance(enemy.player.transform.position, enemy.transform.position);
        if (distanceFromPlayer<=enemy.agent.stoppingDistance)
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
public class AnimationData
{
    [SerializeField] public List<string> chasing;
    [SerializeField] public List<string> attacking;
}