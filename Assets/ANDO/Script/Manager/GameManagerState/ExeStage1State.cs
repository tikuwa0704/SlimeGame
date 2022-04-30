using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class ExeStage1State : State<GameManager>
{
    public ExeStage1State(GameManager owner) : base(owner) { }

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Play("test2");


        ServiceLocator<IUIService>.Instance.SetUIActive("チュートリアル", true);
    }

    public override void Execute()
    {
       
    }

    public override void Exit()
    {

       
    }
}
