using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorRainbow : MonoBehaviour
{
    Image image;

    void Start()
    {
        TryGetComponent(out image);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        image.color = Color.HSVToRGB(Time.time % 1, 1, 1);
    }
}
