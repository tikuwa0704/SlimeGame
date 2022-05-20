using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class ExeStage2State : State<GameManager>
{
    public ExeStage2State(GameManager owner) : base(owner) { }

    CollideJudger fin_stage_collide;

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Play("BGM_クリスマスパーティ",true);

        fin_stage_collide = GameObject.Find("Stage2FinCollide").GetComponent<CollideJudger>();

        SlimeManager.Instance.StopPause();

        Debug.Log("２実行");

        GameObject tutorial;

        if(tutorial = ServiceLocator<IUIService>.Instance.GetUIObject("チュートリアル")){

            tutorial.GetComponent<TutorialManager>().SetTask(owner.stageNum - 1);

        }
    }

    public override void Execute()
    {
        owner.currentGameLimitTime -= Time.deltaTime;

        if (owner.currentGameLimitTime <= 0 || SlimeManager.Instance.GetSlimeNum() <= 0)
        {
            //終わりです
            Debug.Log("制限時間終了");
            owner.ChangeState(E_GAME_MANAGER_STATE.GAMEOVER);
        }

        if (!fin_stage_collide) return;

        if (fin_stage_collide.m_is_collide)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.FIN_STAGE2);
        }
    }

    public override void Exit()
    {
       
    }

}
