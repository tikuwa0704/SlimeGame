using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class ExeStage2State : State<GameManager>
{
    public ExeStage2State(GameManager owner) : base(owner) { }

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Play("BGM_TEST",true);



    }

    public override void Execute()
    {
        owner.currentGameLimitTime -= Time.deltaTime;

        if (owner.currentGameLimitTime <= 0)
        {
            //I‚í‚è‚Å‚·
            Debug.Log("§ŒÀŽžŠÔI—¹");
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
