using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class BeginTitleState : State<GameManager>
{
    public BeginTitleState(GameManager owner) : base(owner) { }

    public override void Enter()
    {
        
    }

    public override void Execute()
    {
        owner.ChangeState(E_GAME_MANAGER_STATE.ExeTITLE);
    }

    public override void Exit()
    {
        
        base.Exit();
    }
}
