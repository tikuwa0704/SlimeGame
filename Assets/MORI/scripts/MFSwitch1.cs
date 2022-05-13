using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFSwitch1 : MonoBehaviour
{
    //public GameObject Isitubute;
    public GameObject Isitubute2;
    public GameObject Isitubute3;
    public GameObject Isitubute4;
    public GameObject Freeze;
    public GameObject Fire;

    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildrenÅió™:SCÅj
        if (collision.gameObject.tag == "SC")
        {
           // Isitubute.SetActive(false);
            Isitubute2.SetActive(false);
            Isitubute3.SetActive(false);
            Isitubute4.SetActive(false);
            Freeze.SetActive(false);
            Fire.SetActive(true);
        }
    }
}
