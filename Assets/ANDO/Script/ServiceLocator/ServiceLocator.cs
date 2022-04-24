using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator<T> where T : class
{
    //�T�[�r�X�̕ێ��E�擾
    public static T Instance { private set; get; }

    //�T�[�r�X�̓o�^
    public static void Bind(T instance)
    {
        Instance = instance;
    }
    //�T�[�r�X�̊J��
    public static void UnBind()
    {
        Instance = null;
    }
}