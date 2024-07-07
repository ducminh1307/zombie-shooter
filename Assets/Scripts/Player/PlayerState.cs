using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachie;
    protected Player player;

    public Vector3 input { get; private set; }

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
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input.Normalize();

        player.anim.SetFloat("magnitue", input.magnitude);

        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit() 
    {
        player.anim.SetBool(animBool, false);
    }
}
