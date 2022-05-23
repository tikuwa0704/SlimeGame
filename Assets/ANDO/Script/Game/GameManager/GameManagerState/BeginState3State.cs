using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;

public class BeginState3State : State<GameManager>
{
    public BeginState3State(GameManager owner) : base(owner) { }

    private PlayableDirector TimeLine;

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.FadeOut("BGM_世界の選択",1);

        ServiceLocator<ISoundService>.Instance.Play("BGM_創造する者", true);

        //現在のステージ設定
        owner.stageNum = 3;

        //タイムリミット設定
        owner.currentGameLimitTime = owner.gameLimitTimes[owner.stageNum - 1];

        //チェックポイント設定
        owner.SetCrrentCheckPoint(owner.stageNum);

        // カーソル非表示
        Cursor.visible = false;
        // カーソルを画面中央にロックする
        Cursor.lockState = CursorLockMode.Locked;

        TimeLine = GameObject.Find("Stage3BeginEvent").GetComponent<PlayableDirector>();
        //ステージのタイムラインをONに
        TimeLine.Play();
        //ムービーを始める

        //プレイヤーを動けなくする
        SlimeManager.Instance.StartPause();

        //カメラ制御
        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);

        owner.ActiveChange(owner.stageNum-1, false);
        owner.ActiveChange(owner.stageNum, true);

    }

    public override void Execute()
    {

        if (TimeLine.time >= 10)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);

        }

        if (TimeLine.time < 9 && Input.GetButton("Fire1"))
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
