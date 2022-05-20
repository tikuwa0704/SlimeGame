using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOScaleBaunce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOScale(new Vector3(7, 2, 0), 1f).SetEase(Ease.OutBounce);
    }

    
}
