using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    //�O���[�o���A�N�Z�X�p
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
        else if (Instance != this) //���g�����ɂ�����悤�Ȃ�
        {
            Destroy(gameObject); //�폜
        }
    }
}
