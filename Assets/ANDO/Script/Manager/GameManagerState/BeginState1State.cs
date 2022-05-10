using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;

public class BeginState1State : State<GameManager>
{

    public BeginState1State(GameManager owner) : base(owner){}

    private PlayableDirector TimeLine;

    public override void Enter()
    {
        // カーソル非表示
        Cursor.visible = false;
        // カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;


        TimeLine = GameObject.Find("StageBeginTimeLine").GetComponent<PlayableDirector>();
        //ステージのタイムラインをONに
        TimeLine.Play();
        //ムービーを始める

        //プレイヤーを動けなくする
        SlimeCoreController.isActive = false;

        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);

    }

    public override void Execute()
    {
        
        if (TimeLine.time >= 10)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);

        }
        
        

    }

    public override void Exit()
    {
        TimeLine.Pause();
        //カメラの移動はできるようにする
        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);
    }
}
