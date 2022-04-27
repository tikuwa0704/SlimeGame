using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;
using UnityEngine.UI;

public class ExeState1State : State<GameManager>
{

    public ExeState1State(GameManager owner) : base(owner) { }

    GameObject text;

    public override void Enter()
    {
        //count_text = GameObject.Find("StageStartText");
       text = ServiceLocator<IUIService>.Instance.GetUIObject("ステージスタート");
        ServiceLocator<IUIService>.Instance.SetUIActive("ステージスタート",true);
        //count_text.GetComponent<CountDownNumber>().enabled = true;
        ServiceLocator<ISoundService>.Instance.Play("カウントダウン");
    }

    public override void Execute()
    {
        ;
        float t = text.GetComponent<CountDownNumber>().time;
        if(t <= -1)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.FinSTAGE1);
        }


    }

    public override void Exit()
    {
        text.GetComponent<CountDownNumber>().enabled = false;

        text.GetComponent<Text>().enabled = false;

        SlimeCoreController.isActive = true;
    }
}
