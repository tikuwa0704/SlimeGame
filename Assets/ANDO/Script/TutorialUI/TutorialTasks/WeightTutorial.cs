using UnityEngine;

public class WeightTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "重量スイッチについて";
    }

    public string GetText()
    {
        return "重量スイッチに一定の重さが乗ると作動して何かが起こります。";
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
