using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponState : PlayerState
{
    private float defaultSpeed;
    protected float lastTimeAttacked;
    public PlayerWeaponState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        defaultSpeed = player.speed;
        player.speed *= .3f;
    }

    public override void Exit()
    {
        base.Exit();
        player.speed = defaultSpeed;
    }

    public override void Update()
    {
        base.Update();
        
        if (input != Vector3.zero)
            player.Move();

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (input == Vector3.zero)
                player.stateMachine.ChangeState(player.idleState);
            else
                player.stateMachine.ChangeState(player.runState);
        }
    }
}
