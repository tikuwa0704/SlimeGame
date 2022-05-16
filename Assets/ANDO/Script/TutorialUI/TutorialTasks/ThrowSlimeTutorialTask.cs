using UnityEngine;

public class ThrowSlimeTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "基本操作　分裂";
    }

    public string GetText()
    {
        return "マウス右クリックで１つスライムを分裂できます。";
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
