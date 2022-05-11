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
        ServiceLocator<ISoundService>.Instance.Play("BGM_シャイニングスター");

        ServiceLocator<IUIService>.Instance.SetUIActive("チュートリアルテキストエリア", true);

        fin_stage_collide = GameObject.Find("Stage1FinCollide").GetComponent<CollideJudger>();
    }

    public override void Execute()
    {
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
