using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;

public class ExeStage1State : State<GameManager>
{
    public ExeStage1State(GameManager owner) : base(owner) { }


    CollideJudger fin_stage_collide;


    public override void Enter()
    {
        ServiceLocator<ISoundService>.Instance.Play("BGM_�V���C�j���O�X�^�[");

        ServiceLocator<IUIService>.Instance.SetUIActive("�`���[�g���A���e�L�X�g�G���A", true);

        fin_stage_collide = GameObject.Find("Stage1FinCollide").GetComponent<CollideJudger>();

        //�X���C���𓮂���悤�ɂ���
        SlimeManager.Instance.StopPause();

        
    }

    public override void Execute()
    {
        owner.currentGameLimitTime -= Time.deltaTime;

        if (owner.currentGameLimitTime <= 0)
        {
            //�I���ł�
            Debug.Log("�������ԏI��");
        }

        if (!fin_stage_collide) return;

        if (fin_stage_collide.m_is_collide)
        {
            owner.ChangeState(E_GAME_MANAGER_STATE.FIN_STAGE1);
        }

    }

    public override void Exit()
    {

       
    }
}