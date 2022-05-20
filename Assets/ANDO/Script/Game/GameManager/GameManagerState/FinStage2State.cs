using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;

public class FinStage2State : State<GameManager>
{
    
    public FinStage2State(GameManager owner) : base(owner){ }


    PlayableDirector m_time_line;
    PlayableDirector m_time_lineScore;

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.FadeOut("BGM_クリスマスパーティ",1);
       

        //プレイヤーを動けなくする
        SlimeManager.Instance.StartPause();


        //スコアを格納
        //残り時間を取得
        owner.SetScore();


        m_time_line = GameObject.Find("Stage2EndEvent").GetComponent<PlayableDirector>();
        m_time_lineScore = GameObject.Find("ScoreEvent").GetComponent<PlayableDirector>();
        //ステージのタイムラインをONに
        m_time_line.Play();
        m_time_lineScore.Play();
        //ムービーを始める
       

        
    }

    public override void Execute()
    {

        if (m_time_line.time >= 12)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.CONECT_2TO3);

        }
    }

    public override void Exit()
    {
        SlimeManager.Instance.StopPause();

        m_time_line.Stop();
        m_time_lineScore.Stop();
       
    }
}
