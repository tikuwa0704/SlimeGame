using UnityEngine;

public class GoalTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "このゲームの目標";
    }

    public string GetText()
    {
        return "制限時間に気を付けながら旗のところまで目指しましょう。そこがゴールです。";
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
