using UnityEngine;

public class SlimeChildTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "�X���C���ɂ���";
    }

    public string GetText()
    {
        return "�X���C���͈�苗�������ƕ��􂵂܂��B��������S�[���ɘA��Ă����Ƃ��̕����������_�ɂȂ�܂��B";
    }

    public void OnTaskSetting()
    {
    }

    public bool CheckTask()
    {
        return true;
    }

    public float GetTransitionTime()
    {
        return 10f;
    }
}
