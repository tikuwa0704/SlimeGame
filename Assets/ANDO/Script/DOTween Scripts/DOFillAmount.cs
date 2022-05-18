using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DOFillAmount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Image image;
        TryGetComponent<Image>(out image);

        image
            .DOFillAmount(0.0f, 1.0f)
            .SetLoops(-1, LoopType.Restart);
            
        Debug.Log("1.0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
