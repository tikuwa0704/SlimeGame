using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaSwitch : MonoBehaviour
{
    public GameObject Magma;
    public GameObject A1;
    public GameObject A2;
    public bool version = false;
    public void OnTriggerEnter(Collider other)
    {
        if (version == false)
        {
            if (other.gameObject.tag == "Player")
            {
                Magma.GetComponent<MagumaUp>().Upswitch = true;
                A1.GetComponent<DownLand>().downland();
                A2.GetComponent<DownLand>().downland();
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
