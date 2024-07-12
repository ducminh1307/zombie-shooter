using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyState
{
    public EnemyDeathState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBool) : base(_enemy, _stateMachine, _animBool)
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
    }
}
