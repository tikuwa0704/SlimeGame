using UnityEngine;

public class GoalTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "���̃Q�[���̖ڕW";
    }

    public string GetText()
    {
        return "�������ԂɋC��t���Ȃ�����̂Ƃ���܂Ŗڎw���܂��傤�B�������S�[���ł��B";
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
