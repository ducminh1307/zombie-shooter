using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBool) : base(_enemy, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.agent.isStopped = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        RotateFollowPlayer();

        if (!enemy.IsPlayerInAttackRange())
            enemy.stateMachine.ChangeState(enemy.chaseState);
    }

    private void RotateFollowPlayer()
    {
        Vector3 direction = (PlayerManager.instance.player.transform.position - enemy.transform.position).normalized;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        enemy.transform.rotation = rotation;
    }
}
