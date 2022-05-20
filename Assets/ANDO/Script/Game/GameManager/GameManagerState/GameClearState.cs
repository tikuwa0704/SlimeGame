using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

using StateMachineAI;
public class GameClearState : State<GameManager>
{

    public GameClearState(GameManager owner): base(owner) { }

    PlayableDirector m_time_line;
    PlayableDirector m_time_lineScore;
    public override void Enter()
    {
        
        // �J�[�\���\��
        Cursor.visible = true;
        // �J�[�\������ʓ��œ�������
        Cursor.lockState = CursorLockMode.Confined;

        m_time_line = GameObject.Find("GameClearEvent").GetComponent<PlayableDirector>();
        
        //�X�e�[�W�̃^�C�����C����ON��
        m_time_line.Play();

    }

    public override void Execute()
    {

        if (m_time_line.time >= 13)
        {
            ServiceLocator<IUIService>.Instance.SetUIActive("�V�[���`�F���W", true);

        }
    }

    public override void Exit()
    {
        
    }
}
