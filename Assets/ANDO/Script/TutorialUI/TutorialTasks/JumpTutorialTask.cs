using UnityEngine;

public class JumpTurorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "��{���� �W�����v";
    }

    public string GetText()
    {
        return "SPACE�L�[�ŃW�����v���܂��B";
    }

    public void OnTaskSetting()
    {
    }

    public bool CheckTask()
    {
        
        if (Input.GetButtonDown("Jump"))
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
