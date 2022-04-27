using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachineAI;
using UnityEngine.UI;

public class FinState1State : State<GameManager>
{

    public FinState1State(GameManager owner) : base(owner) { }

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Play("test2", true);

        ServiceLocator<IUIService>.Instance.SetUIActive("チュートリアル", true);
        
    }

    public override void Execute()
    {

       


    }

    public override void Exit()
    {
        
    }
}
