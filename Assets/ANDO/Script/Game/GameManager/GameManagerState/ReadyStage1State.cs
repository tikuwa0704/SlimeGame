using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;
using UnityEngine.UI;

public class ReadyStage1State : State<GameManager>
{

    public ReadyStage1State(GameManager owner) : base(owner) { }

    GameObject start_text;

    float time;

    public override void Enter()
    {
        
        start_text = ServiceLocator<IUIService>.Instance.GetUIObject("ステージスタートテキストエリア");
        start_text.GetComponent<Text>().enabled = true;

        ServiceLocator<IUIService>.Instance.SetUIActive("ステージスタートテキストエリア", true);
        
        ServiceLocator<ISoundService>.Instance.Play("SE_カウントダウン");

        time = 3.0f;
    }

    public override void Execute()
    {
        time -= Time.deltaTime;

        if (time > -1.0f)
        {
            if (time <= 0)
            {

                start_text.GetComponent<Text>().text = "GAMESTART!";

            }
            else if(time >= 1)
            {
                start_text.GetComponent<Text>().text = time.ToString("F0");
            }
        }
        else
        {
            switch (owner.stageNum)
            {
                case 1:
                    owner.ChangeState(E_GAME_MANAGER_STATE.EXE_STAGE1);
                    break;
                case 2:
                    owner.ChangeState(E_GAME_MANAGER_STATE.EXE_STAGE2);
                    break;
                case 3:
                    owner.ChangeState(E_GAME_MANAGER_STATE.EXE_STAGE3);
                    break;
            }
            
        }

    }

    public override void Exit()
    {
        start_text.GetComponent<Text>().enabled = false;

        
    }
}
