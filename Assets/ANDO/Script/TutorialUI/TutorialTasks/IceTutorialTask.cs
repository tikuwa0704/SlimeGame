using UnityEngine;

public class IceTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "�X��Ԃɂ���";
    }

    public string GetText()
    {
        return "�X��Ԃł͂��ׂ��Ĉړ��ł���悤�ɂȂ�܂��B�������A�W�����v���ł��܂���B�����ŉ�����ł��傤�B";
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
