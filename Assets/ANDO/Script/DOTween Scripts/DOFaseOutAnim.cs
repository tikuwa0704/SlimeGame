using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DOFaseOutAnim : MonoBehaviour
{
    [SerializeField]
    private float beforefadeTime = 5.0f;

    [SerializeField]
    private float fadeTime = 1.0f;

    [SerializeField]
    bool isFade = false;

    private Text text;

    private Image image;

    private void Start()
    {
        text = GetComponent<Text>();

        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        beforefadeTime -= Time.deltaTime;

        if(!isFade&&beforefadeTime <= 0)
        {
            isFade = true;

            if(text)text.DOFade(0, fadeTime);
            if(image)image.DOFade(0, fadeTime);
        }

    }
}
