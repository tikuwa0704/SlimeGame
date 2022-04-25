using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator<T> where T : class
{
    //サービスの保持・取得
    public static T Instance { private set; get; }

    //サービスの登録
    public static void Bind(T instance)
    {
        Instance = instance;
    }
    //サービスの開放
    public static void UnBind()
    {
        Instance = null;
    }
}