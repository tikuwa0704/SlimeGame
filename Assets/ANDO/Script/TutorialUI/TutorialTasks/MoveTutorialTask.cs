using UnityEngine;

public class MoveTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "基本操作 移動";
    }

    public string GetText()
    {
        return "WSADキーで前後左右に移動できます。";
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