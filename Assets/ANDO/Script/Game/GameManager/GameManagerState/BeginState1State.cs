using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;

public class BeginState1State : State<GameManager>
{

    public BeginState1State(GameManager owner) : base(owner){}
    //イベント用のタイムライン
    private PlayableDirector timeLine;

    public override void Enter()
    {
        //合計スコア初期化
        owner.totalScore = 0;
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

        //今回のタイムライン用のオブジェクトを見つける
        timeLine = GameObject.Find("Stage1BeginEvent").GetComponent<PlayableDirector>();
        //ステージのタイムラインをONに
        timeLine.Play();
        //ムービーを始める

        //プレイヤーを動けなくする
        SlimeManager.Instance.StartPause();

        //カメラ切り替え
        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);

        //BGM再生
        ServiceLocator<ISoundService>.Instance.Play("BGM_リコーダーマーチ");

    }

    public override void Execute()
    {
        //タイムラインが10秒を超えたら遷移
        if (timeLine.time >= 10)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);
        }
        //クリックでイベントスキップ
        if (timeLine.time < 9 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            timeLine.time = 9;
        }

    }

    public override void Exit()
    {
        //タイムラインを止める
        timeLine.Stop();
        //カメラを切り替える
        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);
        //BGMをフェードアウトさせる
        ServiceLocator<ISoundService>.Instance.FadeOut("BGM_リコーダーマーチ",3);
    }
}
