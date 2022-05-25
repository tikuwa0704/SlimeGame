using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorRainbow : MonoBehaviour
{
    Image image;

    Text text;

    void Start()
    {
        TryGetComponent(out image);
        TryGetComponent(out text);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(image)image.color = Color.HSVToRGB(Time.time % 1, 1, 1);
        if (text) text.color = Color.HSVToRGB(Time.time % 1, 1, 1);
    }
}
