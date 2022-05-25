using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFSwitch : MonoBehaviour
{
    public Material[] _material;           // 割り当てるマテリアル.
    private int i;

    // public GameObject Isitubute;
    public GameObject Isitubute2;
    public GameObject Isitubute3;
    public GameObject Isitubute4;
    public GameObject Freeze;


    void Start()
    {
        i = 0;
        //m_ObjectCollider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
            this.GetComponent<Renderer>().sharedMaterial = _material[1];
            Isitubute2.SetActive(true);
            Isitubute3.SetActive(true);
            Isitubute4.SetActive(true);
            Freeze.SetActive(true);
        }
    }
}
