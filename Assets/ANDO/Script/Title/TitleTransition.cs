using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTransition : MonoBehaviour
{
    [SerializeField] GameObject click;

    [SerializeField] GameObject menu;

    public void ClickOnTheScreen()
    {
        //���j���[�I���ɐ؂�ւ��
        //OFF�ɂ���
        click.SetActive(false);
        //ON�ɂ���
        menu.SetActive(true);
    }


}
