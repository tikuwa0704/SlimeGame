using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceInstaller : MonoBehaviour
{

    [SerializeField]
    private SoundManager soundManager;

    [SerializeField]
    private UIManager UIManager;


    void Awake()
    {
        //DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        ServiceLocator<ISoundService>.Bind(soundManager); //�T�[�r�X�̓o�^
        ServiceLocator<IUIService>.Bind(UIManager); //�T�[�r�X�̓o�^
    }

    private void OnDestroy()
    {
        ServiceLocator<IGameService>.UnBind(); //�T�[�r�X�̊J��
        ServiceLocator<ISoundService>.UnBind(); //�T�[�r�X�̊J��
        ServiceLocator<IUIService>.UnBind(); //�T�[�r�X�̓o�^
    }
}
