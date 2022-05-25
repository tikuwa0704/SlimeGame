using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BounceScaleFadeOut : MonoBehaviour
{
    [SerializeField]
    private float beforefadeTime = 5.0f;

    [SerializeField]
    private float fadeTime = 1.0f;

    [SerializeField]
    bool isFade = false;

    // Update is called once per frame
    void Update()
    {
        beforefadeTime -= Time.deltaTime;

        if (!isFade && beforefadeTime <= 0)
        {
            isFade = true;

            transform.DOScale(0f, fadeTime);
            
        }

    }
}
