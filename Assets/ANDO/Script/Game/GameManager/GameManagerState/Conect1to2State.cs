using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;
public class Conect1to2State : State<GameManager>
{

    public Conect1to2State(GameManager owner) : base(owner) { }

    CollideJudger fin_stage_collide;

    public override void Enter()
    {
        owner.SetCrrentCheckPoint(2);

        fin_stage_collide = GameObject.Find("Stage2StartCollide").GetComponent<CollideJudger>();

        ServiceLocator<ISoundService>.Instance.Play("BGM_サンタクロースの鈴",true);
    }


    public override void Execute()
    {
        if (SlimeManager.Instance.GetSlimeNum() <= 0)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.GAMEOVER);
        }     

        if (!fin_stage_collide) return;

        if (fin_stage_collide.m_is_collide)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.BEGIN_STAGE2);

        }
    }


    public override void Exit()
    {
        base.Exit();
    }

}
