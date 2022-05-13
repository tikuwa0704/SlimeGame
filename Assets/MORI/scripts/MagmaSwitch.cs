using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaSwitch : MonoBehaviour
{
    public GameObject Magma;
    public bool version = false;
    public void OnTriggerEnter(Collider other)
    {
        if (version == false)
        {
            if (other.gameObject.tag == "Player")
            {
                Magma.GetComponent<MagumaUp>().Upswitch = true;
            }
        }
        if (version == true)
        {
            if (other.gameObject.tag == "Player")
            {
                Magma.GetComponent<MagumaUp>().Upswitch = false;
            }
        }
    }
}
