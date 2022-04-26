using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;

public class BeginState1State : State<GameManager>
{

    public BeginState1State(GameManager owner) : base(owner){}

    private PlayableDirector TimeLine;

    private GameObject Player;

    public override void Enter()
    {
        TimeLine = GameObject.Find("StageBeginTimeLine").GetComponent<PlayableDirector>();
        //ステージのタイムラインをONに
        TimeLine.enabled = true;
        //ムービーを始める

        //プレイヤーを動けなくする
        Player = GameObject.Find("PlayerSlime");
        SlimeCoreController.isActive = false;
        Player.GetComponentInChildren<Cinemachine.CinemachineFreeLook>().enabled = false;

        
    }

    public override void Execute()
    {
        
        if (TimeLine.time >= 10)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.ExeSTAGE1);

        }

    }

    public override void Exit()
    {  
        TimeLine.enabled = false;
        //カメラの移動はできるようにする
        Cinemachine.CinemachineFreeLook cinema = Player.GetComponentInChildren<Cinemachine.CinemachineFreeLook>();
        cinema.enabled = true;
        //カウントダウンが始まる
    }
}
