using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;

public class BeginState1State : State<GameManager>
{

    public BeginState1State(GameManager owner) : base(owner){}

    private PlayableDirector TimeLine;

    public override void Enter()
    {
        // �J�[�\����\��
        Cursor.visible = false;
        // �J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;


        TimeLine = GameObject.Find("StageBeginTimeLine").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        TimeLine.Play();
        //���[�r�[���n�߂�

        //�v���C���[�𓮂��Ȃ�����
        SlimeCoreController.isActive = false;

        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);

    }

    public override void Execute()
    {
        
        if (TimeLine.time >= 10)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);

        }
        
        

    }

    public override void Exit()
    {
        TimeLine.Pause();
        //�J�����̈ړ��͂ł���悤�ɂ���
        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);
    }
}
