using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOver2 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // �L�[����
        if (Input.GetKeyDown(KeyCode.H))
        {

           // transform.DOLocalMove(new Vector3(10f, 10f, 0), 0.5f);
            // ���˂���ۂ�
            transform.DOLocalMoveY(-30f, 2f).SetEase(Ease.OutBounce);
        }
    }

    // �R�[���o�b�N
    private void callback()
    {
    }
}
