using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLand : MonoBehaviour
{
    public bool Down = false;
    public float down;
    public void Update()
    {
        if (Down == true)
        {
            transform.Translate(0f, down, 0f);
        }
    }
    public void downland()
    {
        Down = true;
    }
}
