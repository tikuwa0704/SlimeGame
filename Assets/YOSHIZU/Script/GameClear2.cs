using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameClear2 : MonoBehaviour
{

    [SerializeField] private GameObject Back_Ground;

    GameObject object1;

    public static int State;

    // Start is called before the first frame update
    void Start()
    {
        object1 = GameObject.Find("Hukidasi");
    }

    // Update is called once per frame
    void Update()
    {
        if (Back_Ground)
        {
            var back_Ground = Back_Ground.GetComponent<GameClear1>();
            if (back_Ground.G_Clear)
            {
                if (State <= 10)
                {
                    State++;
                }

                if (State == 10)
                {
                    object1.transform.DOLocalMoveY(100, 2f).SetEase(Ease.OutBounce);
                }
            }
        }
    }
}
