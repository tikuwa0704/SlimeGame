using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class Conect2to3State : State<GameManager>
{

    public Conect2to3State(GameManager owner) : base(owner) { }

    CollideJudger fin_stage_collide;

    public override void Enter()
    {
        owner.SetCrrentCheckPoint(3);

        fin_stage_collide = GameObject.Find("Stage3StartCollide").GetComponent<CollideJudger>();

        ServiceLocator<ISoundService>.Instance.Play("BGM_ê¢äEÇÃëIë", true);

    }


    public override void Execute()
    {
        if (!fin_stage_collide) return;

        if (fin_stage_collide.m_is_collide)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.BEGIN_STAGE3);

        }
    }


    public override void Exit()
    {
        base.Exit();
    }
}
