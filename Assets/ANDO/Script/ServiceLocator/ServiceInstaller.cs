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

    [SerializeField]
    private UIManager UIManager;


    void Awake()
    {
        //DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        if(gameManager)ServiceLocator<IGameService>.Bind(gameManager); //サービスの登録
        if(soundManager)ServiceLocator<ISoundService>.Bind(soundManager); //サービスの登録
        if(UIManager)ServiceLocator<IUIService>.Bind(UIManager); //サービスの登録
    }

    private void OnDestroy()
    {
        ServiceLocator<IGameService>.UnBind(); //サービスの開放
        ServiceLocator<ISoundService>.UnBind(); //サービスの開放
        ServiceLocator<IUIService>.UnBind(); //サービスの登録
    }
}
