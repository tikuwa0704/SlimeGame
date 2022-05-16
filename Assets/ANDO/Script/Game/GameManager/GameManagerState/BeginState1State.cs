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
        //現在のステージ設定
        owner.stageNum = 1;

        //タイムリミット設定
        owner.currentGameLimitTime = owner.gameLimitTimes[owner.stageNum - 1];

        //チェックポイント設定
        owner.SetCrrentCheckPoint(owner.stageNum);

        // カーソル非表示
        Cursor.visible = false;
        // カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;

        TimeLine = GameObject.Find("Stage1BeginEvent").GetComponent<PlayableDirector>();
        //ステージのタイムラインをONに
        TimeLine.Play();
        //ムービーを始める

        //プレイヤーを動けなくする
        SlimeManager.Instance.StartPause();

        //カメラ制御
        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);

    }

    public override void Execute()
    {
        
        if (TimeLine.time >= 10)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);

        }

        if (TimeLine.time < 9 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            TimeLine.time = 9;
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
