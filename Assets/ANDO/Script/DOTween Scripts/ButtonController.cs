using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        transform.DOScale(1.1f, 0.5f).SetEase(Ease.OutElastic).SetLoops(1,LoopType.Yoyo);
       
    }
}

