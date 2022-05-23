using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;

public class BeginState3State : State<GameManager>
{
    public BeginState3State(GameManager owner) : base(owner) { }

    private PlayableDirector TimeLine;

    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.FadeOut("BGM_���E�̑I��",1);

        ServiceLocator<ISoundService>.Instance.Play("BGM_�n�������", true);

        //���݂̃X�e�[�W�ݒ�
        owner.stageNum = 3;

        //�^�C�����~�b�g�ݒ�
        owner.currentGameLimitTime = owner.gameLimitTimes[owner.stageNum - 1];

        //�`�F�b�N�|�C���g�ݒ�
        owner.SetCrrentCheckPoint(owner.stageNum);

        // �J�[�\����\��
        Cursor.visible = false;
        // �J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;

        TimeLine = GameObject.Find("Stage3BeginEvent").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        TimeLine.Play();
        //���[�r�[���n�߂�

        //�v���C���[�𓮂��Ȃ�����
        SlimeManager.Instance.StartPause();

        //�J��������
        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);

        owner.ActiveChange(owner.stageNum-1, false);
        owner.ActiveChange(owner.stageNum, true);

    }

    public override void Execute()
    {

        if (TimeLine.time >= 10)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);

        }

        if (TimeLine.time < 9 && Input.GetButton("Fire1"))
        {
            TimeLine.time = 9;
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
