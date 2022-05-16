using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;

public class FinStage2State : State<GameManager>
{
    
    public FinStage2State(GameManager owner) : base(owner){ }


    PlayableDirector m_time_line;

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Stop("BGM_TEST");
       

        //�v���C���[�𓮂��Ȃ�����
        SlimeManager.Instance.StartPause();

        //�X�R�A���i�[
        //�c�莞�Ԃ��擾
        var limit = owner.currentGameLimitTime;
        int basicScore = 100;
        int score = (int)limit * basicScore;
        owner.gameScore[0] = score;
        owner.currentScore = score;


        m_time_line = GameObject.Find("WallUpEvent").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        m_time_line.Play();
        //���[�r�[���n�߂�

        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);
    }

    public override void Execute()
    {

        if (m_time_line.time >= 13)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.CONECT_1TO2);

        }
    }

    public override void Exit()
    {
        SlimeManager.Instance.StopPause();

        m_time_line.Stop();
        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);
    }
}
