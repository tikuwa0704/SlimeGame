using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSwitch1 : MonoBehaviour
{
    public Material[] _material;           // ���蓖�Ă�}�e���A��.
    private int i;
    public bool Switch=false;

    void Start()
    {
        i = 0;
        //m_ObjectCollider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren�i��:SC�j
        if (collision.gameObject.tag == "SC")
        {
            this.GetComponent<Renderer>().sharedMaterial = _material[1];
            Switch = true;
        }
    }

    public void Color()
    {
        this.GetComponent<Renderer>().sharedMaterial = _material[0];
    }
}
