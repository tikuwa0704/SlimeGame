using UnityEngine;

public class ThrowSlimeTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "��{����@����";
    }

    public string GetText()
    {
        return "�}�E�X�E�N���b�N�łP�X���C���𕪗�ł��܂��B";
    }

    public void OnTaskSetting()
    {
    }

    public bool CheckTask()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            return true;
        }

        return false;
    }

    public float GetTransitionTime()
    {
        return 10f;
    }
}
