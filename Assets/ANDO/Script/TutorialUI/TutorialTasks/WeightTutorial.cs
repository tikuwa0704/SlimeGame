using UnityEngine;

public class WeightTutorialTask : ITutorialTask
{
    public string GetTitle()
    {
        return "�d�ʃX�C�b�`�ɂ���";
    }

    public string GetText()
    {
        return "�d�ʃX�C�b�`�Ɉ��̏d�������ƍ쓮���ĉ������N����܂��B";
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
