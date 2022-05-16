using UnityEngine;

public class SlimeChildTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "スライムについて";
    }

    public string GetText()
    {
        return "スライムは一定距離離れると分裂します。たくさんゴールに連れていくとその分だけ高得点になります。";
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
