using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorswitch : MonoBehaviour
{
    public GameObject Door;
    public bool on=false;
    public int a = 0;//�X���C���̐�
    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren�i��:SC�j
        if (collision.gameObject.tag == "SC")
        {
            if (a <= 99)
            {
                a++;
            }
            if (on == false&&a>=10)
            {
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
        
        //SlimeChildren�i��:SC�j
        if (collision.gameObject.tag == "SC")
        {
            if (on == true&&a<=9)
            {
                Door.GetComponent<Door1>().Left();
                on = false;
            }

        }
    }
}
