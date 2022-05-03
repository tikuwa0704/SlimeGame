using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class FinStage1State : State<GameManager>
{

    public FinStage1State(GameManager owner) : base(owner) { }

    GameObject text;

    float t;

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Stop("test2");

        ServiceLocator<ISoundService>.Instance.Play("äΩê∫");

        SlimeCoreController.isActive = false;

        t = 5.0f;
    }

    public override void Execute()
    {
        t -= Time.deltaTime;

        if (t <= 0)
        {
            ServiceLocator<IGameService>.Instance.TransState(E_GAME_MANAGER_STATE.READY_STAGE2);
        }
    }

    public override void Exit()
    {
        
    }
}

