using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using StateMachineAI;

public class BeginState1State : State<GameManager>
{

    public BeginState1State(GameManager owner) : base(owner){}
    //�C�x���g�p�̃^�C�����C��
    private PlayableDirector timeLine;

    public override void Enter()
    {
        //���v�X�R�A������
        owner.totalScore = 0;
        //���݂̃X�e�[�W�ݒ�
        owner.stageNum = 1;
        //�^�C�����~�b�g�ݒ�
        owner.currentGameLimitTime = owner.gameLimitTimes[owner.stageNum - 1];
        //�`�F�b�N�|�C���g�ݒ�
        owner.SetCrrentCheckPoint(owner.stageNum);

        // �J�[�\����\��
        Cursor.visible = false;
        // �J�[�\������ʒ����Ƀ��b�N����
        Cursor.lockState = CursorLockMode.Locked;

        //����̃^�C�����C���p�̃I�u�W�F�N�g��������
        timeLine = GameObject.Find("Stage1BeginEvent").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        timeLine.Play();
        //���[�r�[���n�߂�

        //�v���C���[�𓮂��Ȃ�����
        SlimeManager.Instance.StartPause();

        //�J�����؂�ւ�
        owner.m_mainCamera.SetActive(false);
        owner.m_subCamera.SetActive(true);

        //BGM�Đ�
        ServiceLocator<ISoundService>.Instance.Play("BGM_���R�[�_�[�}�[�`");

    }

    public override void Execute()
    {
        //�^�C�����C����10�b�𒴂�����J��
        if (timeLine.time >= 10)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.READY_STAGE1);
        }
        //�N���b�N�ŃC�x���g�X�L�b�v
        if (timeLine.time < 9 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            timeLine.time = 9;
        }

    }

    public override void Exit()
    {
        //�^�C�����C�����~�߂�
        timeLine.Stop();
        //�J������؂�ւ���
        owner.m_mainCamera.SetActive(true);
        owner.m_subCamera.SetActive(false);
        //BGM���t�F�[�h�A�E�g������
        ServiceLocator<ISoundService>.Instance.FadeOut("BGM_���R�[�_�[�}�[�`",3);
    }
}
