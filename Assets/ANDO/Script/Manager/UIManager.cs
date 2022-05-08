using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIService
{
    GameObject GetUIObject(string name);
    void SetUIActive(string name, bool isActive);
}



public class UIManager : MonoBehaviour,IUIService
{
    [System.Serializable]
    public class UIData
    {
        public string name;
        public GameObject gameObject;
    }

    [SerializeField]
    private UIData[] UIDatas;

    //�ʖ�(name)���L�[�Ƃ����Ǘ��pDictionary
    private Dictionary<string, UIData> UIDictionary = new Dictionary<string,UIData>();

    private void Awake()
    {
        DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        //soundDictionary�ɃZ�b�g
        foreach (var UIData in UIDatas)
        {
            UIDictionary.Add(UIData.name, UIData);
        }
    }

    //�w�肳�ꂽUI���擾 �Ȃ��ꍇ��null��ԋp
    public GameObject GetUIObject(string name)
    {
        
        if (UIDictionary.TryGetValue(name, out var UIData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            return UIData.gameObject;//����������A�Ԃ�
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }

        return null; //UI�͌�����܂���ł���
    }


    public void SetUIActive(string name,bool isActive)
    {
        var ui = GetUIObject(name);
        if (ui == null) return;
        ui.SetActive(isActive);
    }
}
