using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceInstaller : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;

    void Awake()
    {
        ServiceLocator<ISoundService>.Bind(soundManager); //サービスの登録
    }

    private void OnDestroy()
    {
        ServiceLocator<ISoundService>.UnBind(); //サービスの開放
    }
}
