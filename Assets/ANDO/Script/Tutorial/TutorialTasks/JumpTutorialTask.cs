using UnityEngine;

public class JumpTurorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "基本操作 ジャンプ";
    }

    public string GetText()
    {
        return "SPACEキーでジャンプします。";
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
