using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [Header("Collison info")]
    [SerializeField] private float playerInAttackRange = 1f;
    [SerializeField] private LayerMask whatIsPlayer;

    [Header("Attack check")]
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRadius;

    public NavMeshAgent agent { get; private set; }
    public Player player { get; private set; }

    #region State
    public EnemyStateMachine stateMachine;

    public EnemyChaseState chaseState {  get; private set; }
    public EnemyAttackState attackState {  get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();

        chaseState = new EnemyChaseState(this, stateMachine, "Run");
        attackState = new EnemyAttackState(this, stateMachine, "Attack");
    }

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();

        stateMachine.Initialize(chaseState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), playerInAttackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }

    public bool IsPlayerInAttackRange() => Physics.CheckSphere(transform.position, playerInAttackRange, whatIsPlayer);
    public void AttackTrigger()
    {
        Collider[] colliders = Physics.OverlapSphere(attackCheck.position, attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                //hit.GetComponent<Player>().stats.TakeDamage(stats.damage);
                Debug.Log("Damage");
            }
        }
    }
}
