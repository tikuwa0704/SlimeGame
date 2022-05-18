using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;

public class FinStage1State : State<GameManager>
{

    public FinStage1State(GameManager owner) : base(owner) { }

    PlayableDirector m_time_line;
    PlayableDirector m_time_lineScore;

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.FadeOut("BGM_�݂�Ȃł����ڂ�",1);
        

        //�v���C���[�𓮂��Ȃ�����
        SlimeManager.Instance.StartPause();

        //�X�R�A���i�[
        //�c�莞�Ԃ��擾
        owner.SetScore();

        m_time_line = GameObject.Find("Stage1EndEvent").GetComponent<PlayableDirector>();
        m_time_lineScore = GameObject.Find("ScoreEvent").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        m_time_line.Play();
        m_time_lineScore.Play();
        //���[�r�[���n�߂�

        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);
    }

    public override void Execute()
    {
        
        if (m_time_line.time >= 12)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.CONECT_1TO2);
            
        }
    }

    public override void Exit()
    {
        SlimeManager.Instance.StopPause();

        m_time_line.Stop();
        m_time_lineScore.Stop();
        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);
    }
}

