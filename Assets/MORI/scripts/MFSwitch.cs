using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFSwitch : MonoBehaviour
{
   // public GameObject Isitubute;
    public GameObject Isitubute2;
    public GameObject Isitubute3;
    public GameObject Isitubute4;
    public GameObject Freeze;

    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
           // Isitubute.SetActive(true);
            Isitubute2.SetActive(true);
            Isitubute3.SetActive(true);
            Isitubute4.SetActive(true);
            Freeze.SetActive(true);
        }
    }

   /* private void OnCollisionExit(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {

        }
    }
    public void Miro()
    {
        Isitubute.SetActive(true);
        Isitubute2.SetActive(true);
        Isitubute3.SetActive(true);
        Isitubute4.SetActive(true);
    }

    public void Minnna()
    {
        Isitubute.SetActive(false);
        Isitubute2.SetActive(false);
        Isitubute3.SetActive(false);
        Isitubute4.SetActive(false);
    }*/
}
