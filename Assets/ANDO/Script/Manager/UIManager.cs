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

    //別名(name)をキーとした管理用Dictionary
    private Dictionary<string, UIData> UIDictionary = new Dictionary<string,UIData>();

    private void Awake()
    {
        DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        //soundDictionaryにセット
        foreach (var UIData in UIDatas)
        {
            UIDictionary.Add(UIData.name, UIData);
        }
    }

    //指定されたUIを取得 ない場合はnullを返却
    public GameObject GetUIObject(string name)
    {
        
        if (UIDictionary.TryGetValue(name, out var UIData)) //管理用Dictionary から、別名で探索
        {
            return UIData.gameObject;//見つかったら、返す
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }

        return null; //UIは見つかりませんでした
    }


    public void SetUIActive(string name,bool isActive)
    {
        var ui = GetUIObject(name);
        if (ui == null) return;
        ui.SetActive(isActive);
    }
}
