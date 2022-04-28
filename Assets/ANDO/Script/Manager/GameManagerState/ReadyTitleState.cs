using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class ReadyTitleState : State<GameManager>
{
    public ReadyTitleState(GameManager owner) : base(owner) { }

    public override void Enter()
    {

    }

    public override void Execute()
    {
        owner.ChangeState(E_GAME_MANAGER_STATE.EXE_TITLE);
    }

    public override void Exit()
    {

        base.Exit();
    }
}

