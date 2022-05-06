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
            new Vector3(250f, 0f, 0f),      // �ړ��I���n�_
            30,               // �W�����v�����
            5,               // �W�����v�����
            3.0f              // �A�j���[�V��������
            ).SetRelative().SetLoops(-1, LoopType.Yoyo)
            );

        seq.SetLoops(-1, LoopType.Yoyo);
        //(5,0,0)��1�b�ňړ�����̂�3��J��Ԃ�
        //this.transform.DOMove(new Vector3(100f, 0f, 0f), 3f).SetRelative().SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
