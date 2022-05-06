using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorswitch : MonoBehaviour
{
    public GameObject Door;
    public bool on=false;
    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
            if (on == false)
            {
                Door.GetComponent<Door1>().Right();
                on = true;
            }
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
            if (on == true)
            {
                Door.GetComponent<Door1>().Left();
                on = false;
            }

        }
    }
}
