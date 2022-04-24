using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTransition : MonoBehaviour
{
    [SerializeField] GameObject click;

    [SerializeField] GameObject menu;

    public void ClickOnTheScreen()
    {
        //メニュー選択に切り替わる
        //OFFにする
        click.SetActive(false);
        //ONにする
        menu.SetActive(true);
    }


}
