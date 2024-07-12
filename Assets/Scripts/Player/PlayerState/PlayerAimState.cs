using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimState : PlayerWeaponState
{
    public PlayerAimState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        player.currentWeapon.Fire();
        player.lastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();
    }
}
