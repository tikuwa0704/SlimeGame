using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class GameOverState : State<GameManager>
{
    public GameOverState(GameManager owner) : base(owner) { }

    public override void Enter()
    {
        //���y���~�߂�
        ServiceLocator<ISoundService>.Instance.Stop();
        //���y���~�߂�
        ServiceLocator<ISoundService>.Instance.Play("BGM_�^��2");

        // �J�[�\���\��
        Cursor.visible = true;
        // �J�[�\������ʓ��œ�������
        Cursor.lockState = CursorLockMode.Confined;

        //�v���C���[�𓮂��Ȃ�����
        SlimeManager.Instance.StartPause();
        //GAMEOVERUI������
        ServiceLocator<IUIService>.Instance.SetUIActive("�Q�[���I�[�o�[",true);
        ServiceLocator<IUIService>.Instance.SetUIActive("�V�[���`�F���W", true);
    }

    public override void Execute()
    {
       

    }

    public override void Exit()
    {
       
    }

}
