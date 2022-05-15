using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITutorialTask
{
    /// <summary>
    /// �`���[�g���A���̃^�C�g�����擾����
    /// </summary>
    /// <returns></returns>
    string GetTitle();

    /// <summary>
    /// ���������擾����
    /// </summary>
    /// <returns></returns>
    string GetText();

    /// <summary>
    /// �`���[�g���A���^�X�N���ݒ肳�ꂽ�ۂɎ��s�����
    /// </summary>
    void OnTaskSetting();

    /// <summary>
    /// �`���[�g���A�����B�����ꂽ�����肷��
    /// </summary>
    /// <returns></returns>
    bool CheckTask();

    /// <summary>
    /// �B����Ɏ��̃^�X�N�֑J�ڂ���܂ł̎���(�b)
    /// </summary>
    /// <returns></returns>
    float GetTransitionTime();
}
