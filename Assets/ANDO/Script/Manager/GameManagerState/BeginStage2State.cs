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
        SlimeCoreController.isActive = false;//�v���C���[�𓮂��Ȃ�����
        SlimeCoreController.rb.velocity = Vector3.zero;
        SlimeCoreController.rb.isKinematic = true;

        m_time_line = GameObject.Find("Stage2BeginEvent").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        m_time_line.Play();
        //���[�r�[���n�߂�

        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);
    }


    public override void Execute()
    {
        if(m_time_line.time >= 15.0f)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.EXE_STAGE2);
        }
    }

    public override void Exit()
    {
        SlimeCoreController.isActive = true;//�v���C���[�𓮂��Ȃ�����
        SlimeCoreController.rb.isKinematic = false;

        m_time_line.Stop();
        //���[�r�[���n�߂�

        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);
    }

}
