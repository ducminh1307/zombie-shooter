using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerState
{
    public PlayerMovementState(Player _player, PlayerStateMachine _stateMachine, string _animBool) : base(_player, _stateMachine, _animBool)
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            switch (player.currentWeapon.weapon.typeWeapon)
            {
                case WeaponType.Rfile:
                    player.stateMachine.ChangeState(player.firingState);
                    break;
                case WeaponType.Grenade:
                    player.stateMachine.ChangeState(player.aimState);
                    break;
            }
        }
    }
}
