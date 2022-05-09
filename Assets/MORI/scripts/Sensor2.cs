using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor2 : MonoBehaviour
{
    public bool On = false;
    public GameObject Yukineko;
    public GameObject Yukineko2;
    public GameObject Yukineko3;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (On == false)
            {
                Yukineko.GetComponent<Snowball>().Exciting2();
                Yukineko2.GetComponent<Snowball>().Exciting();
                Yukineko3.GetComponent<Snowball>().Exciting2();
                Debug.Log("•@–Ñ");
                On = true;
            }
           
        }
    }
}
