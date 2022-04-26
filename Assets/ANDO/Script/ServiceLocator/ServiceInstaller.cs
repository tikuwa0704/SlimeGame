using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceInstaller : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private SoundManager soundManager;

    void Awake()
    {
        DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        ServiceLocator<IGameService>.Bind(gameManager); //サービスの登録
        ServiceLocator<ISoundService>.Bind(soundManager); //サービスの登録
    }

    private void OnDestroy()
    {
        ServiceLocator<IGameService>.UnBind(); //サービスの開放
        ServiceLocator<ISoundService>.UnBind(); //サービスの開放
    }
}
