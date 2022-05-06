using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallleft : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(new Vector3(0.01f, 0, 0));
    }
}
