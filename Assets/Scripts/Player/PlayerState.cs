using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachie;
    protected Player player;

    private string animBool;

    protected float stateTimer;
    protected bool triggerCalled;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBool)
    {
        player = _player;
        stateMachie = _stateMachine;
        animBool = _animBool;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBool, true);

        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit() 
    {
        player.anim.SetBool(animBool, false);
    }
}
