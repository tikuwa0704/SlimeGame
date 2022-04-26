using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;
using UnityEngine.UI;

public class ExeState1State : State<GameManager>
{

    public ExeState1State(GameManager owner) : base(owner) { }

    private GameObject Player;

    private GameObject count_text;

    public override void Enter()
    {
       
       //ステージのタイムラインをONに

       //プレイヤーを動けなくする
       Player = GameObject.Find("PlayerSlime");


        count_text = GameObject.Find("StageStartText");
        count_text.GetComponent<CountDownNumber>().enabled = true;

    }

    public override void Execute()
    {

        if(count_text.GetComponent<CountDownNumber>().time <= -1)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.FinSTAGE1);
        }


    }

    public override void Exit()
    {
        count_text.GetComponent<CountDownNumber>().enabled = false;

        count_text.GetComponent<Text>().enabled = false;

        SlimeCoreController.isActive = true;
    }
}
