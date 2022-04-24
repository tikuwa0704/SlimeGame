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
        ServiceLocator<ISoundService>.Bind(soundManager); //�T�[�r�X�̓o�^
    }

    private void OnDestroy()
    {
        ServiceLocator<ISoundService>.UnBind(); //�T�[�r�X�̊J��
    }
}
