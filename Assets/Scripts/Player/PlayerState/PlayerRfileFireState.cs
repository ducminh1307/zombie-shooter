using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRfileFireState : PlayerWeaponState
{
    public PlayerRfileFireState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
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

        if (player.lastTimeAttack + player.currentWeapon.weapon.fireRate <= Time.time)
        {
            player.currentWeapon.Fire();
            player.lastTimeAttack = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (input == Vector3.zero)
                player.stateMachine.ChangeState(player.idleState);
            else
                player.stateMachine.ChangeState(player.runState);
        }
    }
}
