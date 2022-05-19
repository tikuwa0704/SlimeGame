using UnityEngine;

public class IceTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "氷状態について";
    }

    public string GetText()
    {
        return "氷状態ではすべって移動できるようになります。しかし、ジャンプができません。高温で解けるでしょう。";
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
