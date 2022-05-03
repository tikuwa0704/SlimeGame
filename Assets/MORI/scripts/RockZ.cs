using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockZ : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, 0, -0.05f));
    }
}
