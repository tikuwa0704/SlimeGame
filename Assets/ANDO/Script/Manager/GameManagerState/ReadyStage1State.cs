using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;
using UnityEngine.UI;

public class ReadyStage1State : State<GameManager>
{

    public ReadyStage1State(GameManager owner) : base(owner) { }

    GameObject text;

    public override void Enter()
    {
        
       
        text = ServiceLocator<IUIService>.Instance.GetUIObject("ステージスタート");
        ServiceLocator<IUIService>.Instance.SetUIActive("ステージスタート",true);
        
        ServiceLocator<ISoundService>.Instance.Play("カウントダウン");
    }

    public override void Execute()
    {
        ;
        float t = text.GetComponent<CountDownNumber>().time;
        if(t <= -1)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.EXE_STAGE1);
        }


    }

    public override void Exit()
    {
        text.GetComponent<CountDownNumber>().enabled = false;

        text.GetComponent<Text>().enabled = false;

        SlimeCoreController.isActive = true;
    }
}
