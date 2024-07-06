using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Quaternion rotation = Quaternion.Euler(0, 45, 0);
        Vector3 finalDirection = rotation * input;
        player.rb.velocity = finalDirection.normalized * player.speed;

        if (input == Vector3.zero)
            player.stateMachine.ChangeState(player.idleState);

        Debug.Log(player.rb.velocity);
    }
}
