using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StateMachineAI;


public class TitleManager : SingletonMonoBehaviour<TitleManager>
{
    public enum E_TITLE_STATE{
        E_TITLE_BEGIN,//オープニング
        E_TITLE_EXE,
        E_TITLE_END,
    }

    [SerializeField]
    E_TITLE_STATE m_state { get; set; }

    private void Start()
    {
        m_state = E_TITLE_STATE.E_TITLE_BEGIN;
    }

    private void Update()
    {
        switch (m_state)
        {
            case E_TITLE_STATE.E_TITLE_BEGIN:
                TitleBegin();
                break;
            case E_TITLE_STATE.E_TITLE_EXE:
                TitleExe();
                break;
            case E_TITLE_STATE.E_TITLE_END:
                TitleEnd();
                break;
        }
    }

    void TitleBegin()
    {
        ServiceLocator<ISoundService>.Instance.Play("test", true);
        m_state = E_TITLE_STATE.E_TITLE_EXE;
    }


    void TitleExe()
    {
        
    }

    void TitleEnd()
    {
        ServiceLocator<IUIService>.Instance.SetUIActive("オープニング", false);
        ServiceLocator<IUIService>.Instance.SetUIActive("タイトル", false);
        ServiceLocator<IUIService>.Instance.SetUIActive("バックグラウンド", false);
        ServiceLocator<IUIService>.Instance.SetUIActive("タイトルメニューエリア", false);
    }


}
