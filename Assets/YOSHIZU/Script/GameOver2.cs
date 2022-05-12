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

        // キー入力
        if (Input.GetKeyDown(KeyCode.H))
        {

            transform.DOLocalMoveY(100, 2f).SetEase(Ease.OutBounce);
            // 跳ねるっぽく
            //transform.DOLocalMoveY(-30f, 2f).SetEase(Ease.OutBounce);
        }
    }

    // コールバック
    private void callback()
    {
    }
}
