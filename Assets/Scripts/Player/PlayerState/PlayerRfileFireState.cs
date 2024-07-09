using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRfileFireState : PlayerWeaponState
{
    private float defaultSpeed;
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

        if (stateTimer <= 0)
        {
            player.currentWeapon.Fire();
            stateTimer = player.currentWeapon.weapon.fireRate;
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
