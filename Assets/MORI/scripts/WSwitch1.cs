using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSwitch1 : MonoBehaviour
{
    public bool Switch=false;
    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren�i��:SC�j
        if (collision.gameObject.tag == "SC")
        {
            Switch = true;
        }
    }
}
