using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTransition : MonoBehaviour
{
    [SerializeField] GameObject click;

    [SerializeField] GameObject menu;

    public void ClickOnTheScreen()
    {
        //ƒƒjƒ…[‘I‘ğ‚ÉØ‚è‘Ö‚í‚é
        //OFF‚É‚·‚é
        click.SetActive(false);
        //ON‚É‚·‚é
        menu.SetActive(true);
    }


}
