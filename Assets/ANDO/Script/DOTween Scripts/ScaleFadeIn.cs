using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleFadeIn : MonoBehaviour
{

    void ShowWindow()
    {
        transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        ShowWindow();
    }
}
