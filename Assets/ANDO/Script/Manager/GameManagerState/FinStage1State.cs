using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;

public class FinStage1State : State<GameManager>
{

    public FinStage1State(GameManager owner) : base(owner) { }

    PlayableDirector m_time_line;

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Stop("BGM_�V���C�j���O�X�^�[");

        ServiceLocator<ISoundService>.Instance.Play("SE_�����Ɣ���");

        SlimeCoreController.isActive = false;//�v���C���[�𓮂��Ȃ�����

        m_time_line = GameObject.Find("WallUpEvent").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        m_time_line.Play();
        //���[�r�[���n�߂�

        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);
    }

    public override void Execute()
    {
        
        if (m_time_line.time >= 10)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.CONECT_1TO2);
            SlimeCoreController.isActive = true;
        }
    }

    public override void Exit()
    {
        m_time_line.Stop();
        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);
    }
}

