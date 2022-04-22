using UnityEngine;

public class MoveTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "��{���� �ړ�";
    }

    public string GetText()
    {
        return "WSAD�L�[�őO�㍶�E�Ɉړ��ł��܂��B";
    }

    public void OnTaskSetting()
    {
    }

    public bool CheckTask()
    {
        float axis_h = Input.GetAxis("Horizontal");
        float axis_v = Input.GetAxis("Vertical");

        if (0 < axis_v || 0 < axis_h)
        {
            return true;
        }

        return false;
    }

    public float GetTransitionTime()
    {
        return 5f;
    }
}