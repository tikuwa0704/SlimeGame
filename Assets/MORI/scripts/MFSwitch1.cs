using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFSwitch1 : MonoBehaviour
{
    public Material[] _material;           // ���蓖�Ă�}�e���A��.
    private int i;
    //public GameObject Isitubute;
    public GameObject Isitubute2;
    public GameObject Isitubute3;
    public GameObject Isitubute4;
    public GameObject Freeze;
    public GameObject Fire;

    void Start()
    {
        i = 0;
        //m_ObjectCollider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren�i��:SC�j
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Renderer>().sharedMaterial = _material[1];
            // Isitubute.SetActive(false);
            Isitubute2.SetActive(false);
            Isitubute3.SetActive(false);
            Isitubute4.SetActive(false);
            Freeze.SetActive(false);
            Fire.SetActive(true);
        }
    }
}
