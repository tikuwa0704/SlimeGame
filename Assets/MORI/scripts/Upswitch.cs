using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upswitch : MonoBehaviour
{
    public Material[] _material;           // ���蓖�Ă�}�e���A��.
    private int i;
    public bool reset = false;

    public GameObject Elevator;
    public bool on = false;


    void Start()
    {
        i = 0;
        //m_ObjectCollider = GetComponent<Collider>();
    }

    public void Update()
    {
        //{
        if (reset == true)
        {
            //�ʏ�J���[�X���C����
            this.GetComponent<Renderer>().sharedMaterial = _material[0];
            reset = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren�i��:SC�j
        if (collision.gameObject.tag == "SC")
        {
            if (on == false)
            {
                this.GetComponent<Renderer>().sharedMaterial = _material[1];
                Elevator.GetComponent<UpLand2>().ElevatorON();
                on = true;
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //SlimeChildren�i��:SC�j
        if (collision.gameObject.tag == "SC")
        {      
                on = false;
                reset = true;
        }
    }
}
