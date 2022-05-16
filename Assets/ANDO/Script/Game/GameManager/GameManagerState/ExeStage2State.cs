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
        ServiceLocator<ISoundService>.Instance.Play("BGM_TEST",true);

        fin_stage_collide = GameObject.Find("Stage2FinCollide").GetComponent<CollideJudger>();

        Debug.Log("ÇQé¿çs");
    }

    public override void Execute()
    {
        owner.currentGameLimitTime -= Time.deltaTime;

        if (owner.currentGameLimitTime <= 0)
        {
            //èIÇÌÇËÇ≈Ç∑
            Debug.Log("êßå¿éûä‘èIóπ");
        }

        if (!fin_stage_collide) return;

        if (fin_stage_collide.m_is_collide)
        {
            //owner.ChangeState(E_GAME_MANAGER_STATE.FIN_STAGE2);
        }
    }

    public override void Exit()
    {
       
    }

}
