using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    //グローバルアクセス用
    public static T Instance
    {
        private set;
        get;
    }

    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this.GetComponent<T>();
        }
        else if (Instance != this) //自身が他にもあるようなら
        {
            Destroy(gameObject); //削除
        }
    }
}
