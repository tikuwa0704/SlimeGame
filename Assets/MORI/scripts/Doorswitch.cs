using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorswitch : MonoBehaviour
{
    public Material[] _material;           // 割り当てるマテリアル.
    private int i;
    public bool reset = false;

    public GameObject Door;
    public bool on=false;
    public int a = 0;//スライムの数
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
            //通常カラースライム緑
            this.GetComponent<Renderer>().sharedMaterial = _material[0];
            reset = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
            if (a <= 99)
            {
                a++;
            }
            if (on == false&&a>=10)
            {
                this.GetComponent<Renderer>().sharedMaterial = _material[1];
                Door.GetComponent<Door1>().Right();
                on = true;
            }
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (a != 0)
        {
            a--;
        }
        
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
            if (on == true&&a<=9)
            {
                Door.GetComponent<Door1>().Left();
                on = false;
                reset = true;
            }

        }
    }
}
