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
        

        //�v���C���[�𓮂��Ȃ�����
        SlimeManager.Instance.StartPause();
        //GAMEOVERUI������
        ServiceLocator<IUIService>.Instance.SetUIActive("GAMEOVER�e�L�X�g�G���A",true);
        
    }

    public override void Execute()
    {
       

    }

    public override void Exit()
    {
       
    }

}
