using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upswitch : MonoBehaviour
{
    public GameObject Elevator;
    public bool on = false;

    private void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
            if (on == false)
            {
                Elevator.GetComponent<UpLand2>().ElevatorON();
                on = true;
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {      
                on = false;

        }
    }
}
