using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOver2 : MonoBehaviour
{
    [SerializeField] private GameObject Back_Ground;

    public static int State;

    GameObject object1;
    GameObject object2;
    GameObject object3;
    GameObject object4;
    GameObject object5;
    GameObject object6;
    GameObject object7;
    GameObject object8;

    // Use this for initialization
    void Start()
    {
        object1 = GameObject.Find("G");
        object2 = GameObject.Find("A");
        object3 = GameObject.Find("M");
        object4 = GameObject.Find("E1");
        object5 = GameObject.Find("O");
        object6 = GameObject.Find("V");
        object7 = GameObject.Find("E2");
        object8 = GameObject.Find("R");
    }

    // Update is called once per frame
    void Update()
    { 
        if (Back_Ground)
        {
            var back_Ground = Back_Ground.GetComponent<GameOver1>();
            if (back_Ground.G_Over)
            {
                if (State <= 400)
                {
                    State++;
                }

                if (State == 50)
                {
                    object1.transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                }

                if (State == 100)
                {
                    object2.transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                }

                if (State == 150)
                {
                    object3.transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                }
                if (State == 200)
                {
                    object4.transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                }

                if (State == 250)
                {
                    object5.transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                }

                if (State == 300)
                {
                    object6.transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                }

                if (State == 350)
                {
                    object7.transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                }

                if (State == 400)
                {
                    object8.transform.DOLocalMoveY(50, 2f).SetEase(Ease.OutBounce);
                }
            }
        }
    }

    // コールバック
    private void callback()
    {
    }
}
