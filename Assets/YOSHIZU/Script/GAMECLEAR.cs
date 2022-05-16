using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GAMECLEAR : MonoBehaviour
{
    int State;
    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            this.transform.DOScale(new Vector3(7, 2, 0), 1f).SetEase(Ease.OutBounce);
        }
    }
    /*
    public GameObject panel;
    private bool isDefaultScale;

    void Start()
    {
        panel = GameObject.Find("GameClear");
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (isDefaultScale)
            {
                panel.transform.DOScale(new Vector3(-1, -1, -1), 0.2f);
                isDefaultScale = false;
                //   panel.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
                //   isDefaultScale = false;
            }
            /*
            else if (!isDefaultScale)
            {
                panel.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
                isDefaultScale = true;
            }
            
        }
    }
*/
}
