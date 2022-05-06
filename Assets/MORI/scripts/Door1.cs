using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public void Right()
    {
        this.transform.Translate(new Vector3(11.0f, 0, 0));
    }

    public void Left()
    {
        this.transform.Translate(new Vector3(-11.0f, 0, 0));
    }
}
