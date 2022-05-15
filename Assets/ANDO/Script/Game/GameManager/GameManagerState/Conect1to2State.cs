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
    }


    public override void Execute()
    {
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