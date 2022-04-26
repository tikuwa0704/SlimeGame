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
        TimeLine = GameObject.Find("StageBeginTimeLine").GetComponent<PlayableDirector>();
        //�X�e�[�W�̃^�C�����C����ON��
        TimeLine.enabled = true;
        //���[�r�[���n�߂�

        //�v���C���[�𓮂��Ȃ�����
        Player = GameObject.Find("PlayerSlime");
        SlimeCoreController.isActive = false;
        Player.GetComponentInChildren<Cinemachine.CinemachineFreeLook>().enabled = false;

        
    }

    public override void Execute()
    {
        
        if (TimeLine.time >= 10)
        {

            owner.ChangeState(E_GAME_MANAGER_STATE.ExeSTAGE1);

        }

    }

    public override void Exit()
    {  
        TimeLine.enabled = false;
        //�J�����̈ړ��͂ł���悤�ɂ���
        Cinemachine.CinemachineFreeLook cinema = Player.GetComponentInChildren<Cinemachine.CinemachineFreeLook>();
        cinema.enabled = true;
        //�J�E���g�_�E�����n�܂�
    }
}
