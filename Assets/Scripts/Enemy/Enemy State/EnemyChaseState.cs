using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBool) : base(_enemy, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.agent.isStopped = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.agent.SetDestination(PlayerManager.instance.player.transform.position);

        if (enemy.IsPlayerInAttackRange())
            enemy.stateMachine.ChangeState(enemy.attackState);
    }
}
