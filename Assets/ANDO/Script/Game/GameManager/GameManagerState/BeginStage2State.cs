using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;

public class BeginStage2State : State<GameManager>
{

    public BeginStage2State(GameManager owner) : base(owner) { }

    PlayableDirector m_time_line;

    public override void Enter()
    {
        owner.stageNum = 2;

        //�^�C�����~�b�g�ݒ�
        owner.currentGameLimitTime = owner.gameLimitTimes[owner.stageNum - 1];

        SlimeManager.Instance.StartPause();

        m_time_line = GameObject.Find("Stage2BeginEvent").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        m_time_line.Play();
        //���[�r�[���n�߂�

        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);

        owner.ActiveChange(owner.stageNum-1, false);
        owner.ActiveChange(owner.stageNum, true);
    }


    public override void Execute()
    {
        if(m_time_line.time >= 13.0f)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);
        }

        if (m_time_line.time < 12.0f&&Input.GetButton("Fire1"))
        {
            m_time_line.time = 12.0f;
        }
    }

    public override void Exit()
    {
        
        m_time_line.Stop();
        //���[�r�[���n�߂�

        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);

        ServiceLocator<ISoundService>.Instance.FadeOut("BGM_�T���^�N���[�X�̗�",5);
    }

}
