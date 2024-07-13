using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachie;
    protected Enemy enemy;

    private string animBool;

    protected float stateTimer;
    protected bool triggerCalled;

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBool)
    {
        enemy = _enemy;
        stateMachie = _stateMachine;
        animBool = _animBool;
    }

    public virtual void Enter()
    {
        enemy.anim.SetBool(animBool, true);
        triggerCalled = false;
    }

    public virtual void Exit() 
    {
        enemy.anim.SetBool(animBool, false);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
}
