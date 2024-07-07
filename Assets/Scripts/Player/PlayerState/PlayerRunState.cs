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
        player.Move();

        if (input == Vector3.zero)
            player.stateMachine.ChangeState(player.idleState);
        if (Input.GetKeyDown(KeyCode.Mouse0))
            player.stateMachine.ChangeState(player.firingState);
    }
}
