using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear1 : MonoBehaviour
{
    float alfa;
    float speed = 0.01f;
    float red, green, blue;
    public bool G_ClearÅ@= false;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;
        if (alfa >= 1)
        {
            G_Clear = true;
        }
    }
}
