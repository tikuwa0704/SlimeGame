using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class ExeStage1State : State<GameManager>
{
    public ExeStage1State(GameManager owner) : base(owner) { }


    CollideJudger fin_stage_collide;


    public override void Enter()
    {
        //ステージ１の音楽
        ServiceLocator<ISoundService>.Instance.Play("BGM_みんなであそぼう",true);
        //チュートリアル説明テキストを有効に
        ServiceLocator<IUIService>.Instance.SetUIActive("チュートリアルテキストエリア", true);
        //ゴールのコライダー有効にする
        fin_stage_collide = GameObject.Find("Stage1FinCollide").GetComponent<CollideJudger>();
        //スライムを動けないようにする
        SlimeManager.Instance.StopPause();
    }

    public override void Execute()
    {
        owner.currentGameLimitTime -= Time.deltaTime;

        if (owner.currentGameLimitTime <= 0)
        {
            //終わりです
            Debug.Log("制限時間終了");
            owner.ChangeState(E_GAME_MANAGER_STATE.GameOver);
        }

        if (!fin_stage_collide) return;

        if (fin_stage_collide.m_is_collide)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.FIN_STAGE1);
        }

    }

    public override void Exit()
    {

       
    }
}
