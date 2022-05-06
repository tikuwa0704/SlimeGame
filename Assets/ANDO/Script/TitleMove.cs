using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TitleMove : MonoBehaviour
{
    RectTransform rectTransform;
    
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rectTransform);
        //rectTransform.DOMove(new Vector3(0f, 0f, 0f), 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutBounce);
        Sequence seq = DOTween.Sequence();

        /*
        seq.Append(
        rectTransform.DOScale(new Vector3(1.1f, 1.1f), 1.0f).SetLoops(-1, LoopType.Restart)
        );
        */


        seq.Join(
        rectTransform.DOLocalJump(
            new Vector3(250f, 0f, 0f),      // 移動終了地点
            30,               // ジャンプする力
            5,               // ジャンプする回数
            3.0f              // アニメーション時間
            ).SetRelative().SetLoops(-1, LoopType.Yoyo)
            );

        seq.SetLoops(-1, LoopType.Yoyo);
        //(5,0,0)へ1秒で移動するのを3回繰り返す
        //this.transform.DOMove(new Vector3(100f, 0f, 0f), 3f).SetRelative().SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
