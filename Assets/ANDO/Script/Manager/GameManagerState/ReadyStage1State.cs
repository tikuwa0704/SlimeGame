using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;
using UnityEngine.UI;

public class ReadyStage1State : State<GameManager>
{

    public ReadyStage1State(GameManager owner) : base(owner) { }

    GameObject text;

    public override void Enter()
    {
        
       
        text = ServiceLocator<IUIService>.Instance.GetUIObject("�X�e�[�W�X�^�[�g");
        ServiceLocator<IUIService>.Instance.SetUIActive("�X�e�[�W�X�^�[�g",true);
        
        ServiceLocator<ISoundService>.Instance.Play("�J�E���g�_�E��");
    }

    public override void Execute()
    {
        ;
        float t = text.GetComponent<CountDownNumber>().time;
        if(t <= -1)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.EXE_STAGE1);
        }


    }

    public override void Exit()
    {
        text.GetComponent<CountDownNumber>().enabled = false;

        text.GetComponent<Text>().enabled = false;

        SlimeCoreController.isActive = true;
    }
}
