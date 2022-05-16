using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;

public class BeginStage2State : State<GameManager>
{

    public BeginStage2State(GameManager owner) : base(owner) { }

    PlayableDirector m_time_line;

    public override void Enter()
    {
        owner.stageNum = 2;

        //タイムリミット設定
        owner.currentGameLimitTime = owner.gameLimitTimes[owner.stageNum - 1];

        SlimeManager.Instance.StartPause();

        m_time_line = GameObject.Find("Stage2BeginEvent").GetComponent<PlayableDirector>();
        //ステージのタイムラインをONに
        m_time_line.Play();
        //ムービーを始める

        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);
    }


    public override void Execute()
    {
        if(m_time_line.time >= 15.0f)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);
        }
    }

    public override void Exit()
    {
        
        m_time_line.Stop();
        //ムービーを始める

        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);

        ServiceLocator<ISoundService>.Instance.FadeOut("BGM_サンタクロースの鈴",5);
    }

}
