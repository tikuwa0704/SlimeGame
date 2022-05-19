using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class ExeStage3State : State<GameManager>
{
    
    public ExeStage3State(GameManager owner) : base(owner) { }


    CollideJudger fin_stage_collide;

    public override void Enter()
    {
        //ServiceLocator<ISoundService>.Instance.FadeOut("BGM_創造する者", 1);

        //ServiceLocator<ISoundService>.Instance.Play("BGM_攻城戦", true);


        fin_stage_collide = GameObject.Find("Stage3EndCollide").GetComponent<CollideJudger>();

        SlimeManager.Instance.StopPause();

        Debug.Log("3実行");

        GameObject tutorial;

        if (tutorial = ServiceLocator<IUIService>.Instance.GetUIObject("チュートリアルテキストエリア"))
        {

            tutorial.GetComponent<TutorialManager>().SetTask(owner.stageNum - 1);

        }
    }

    public override void Execute()
    {
        owner.currentGameLimitTime -= Time.deltaTime;

        if (owner.currentGameLimitTime <= 0)
        {
            //終わりです
            Debug.Log("制限時間終了");
        }

        if (!fin_stage_collide) return;

        if (fin_stage_collide.m_is_collide)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.FIN_STAGE3);
        }
    }

    public override void Exit()
    {

    }


}
