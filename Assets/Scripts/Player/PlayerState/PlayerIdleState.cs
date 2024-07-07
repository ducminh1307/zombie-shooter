using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerMovementState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public override void Exit()
    {
        base.Exit();
        player.rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public override void Update()
    {
        base.Update();
        if (input != Vector3.zero)
            player.stateMachine.ChangeState(player.runState);
    }
}
