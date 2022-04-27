using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class ExeTitleState : State<GameManager>
{
    public ExeTitleState(GameManager owner) : base(owner) { }

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Play("test", true);
        base.Enter();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        
        base.Exit();
    }
}
