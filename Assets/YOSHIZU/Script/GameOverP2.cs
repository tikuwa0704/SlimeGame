using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverP2 : MonoBehaviour
{
    [SerializeField] private GameObject Back_Ground;

    GameObject object1;

    public static int State;
    public bool G_Over_Change = false;
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
            var back_Ground = Back_Ground.GetComponent<GameOverP1>();
            if (back_Ground.G_Over)
            {
                if (State <= 200)
                {
                    State++;
                }

                if (State == 10)
                {
                    object1.transform.DOLocalMoveY(100, 2f).SetEase(Ease.OutBounce);

                }

                if (State == 200)
                {
                    G_Over_Change = true;
                }
            }
        }
    }
}
