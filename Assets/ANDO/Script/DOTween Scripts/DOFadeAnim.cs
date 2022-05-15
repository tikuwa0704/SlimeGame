using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class DOFadeAnim : MonoBehaviour
{
    private void Awake()
    {
        var text = GetComponent<Text>();
        text.DOFade(0, 1.0f).SetLoops(-1, LoopType.Yoyo);

    }
   
}
