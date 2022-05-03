using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;

public class BeginState1State : State<GameManager>
{

    public BeginState1State(GameManager owner) : base(owner){}

    private PlayableDirector TimeLine;

    private GameObject Player;

    public override void Enter()
    {
        
        ServiceLocator<IUIService>.Instance.SetUIActive("�I�[�v�j���O", false);
        ServiceLocator<IUIService>.Instance.SetUIActive("�^�C�g��", false);
        ServiceLocator<IUIService>.Instance.SetUIActive("�o�b�N�O���E���h", false);

        // �J�[�\����\��
        Cursor.visible = false;
        // �J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;


        TimeLine = GameObject.Find("StageBeginTimeLine").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        TimeLine.enabled = true;
        //���[�r�[���n�߂�

        //�v���C���[�𓮂��Ȃ�����
        Player = GameObject.Find("PlayerSlime");
        SlimeCoreController.isActive = false;
        Player.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>().enabled = false;

        
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
        TimeLine.enabled = false;
        //�J�����̈ړ��͂ł���悤�ɂ���
        Cinemachine.CinemachineVirtualCamera cinema = Player.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();
        cinema.enabled = true;
        //�J�E���g�_�E�����n�܂�
    }
}
