using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagumaUp : MonoBehaviour
{
    public bool Upswitch = false;
    public float up;
    // Update is called once per frame
    void Update()
    {
        if (Upswitch == true)
        {
            transform.Translate(0f, up, 0f);
        }
    }
}
