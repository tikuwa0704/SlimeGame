using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public GameObject sensorR;
    public GameObject sensorL;
    public bool switchON=false;
    private void OnCollisionEnter(Collision collision)
    {
       /* if (collision.gameObject.tag == "Player")
        {
            if (switchON == false)
            {
                sensorR.GetComponent<Breath>().BreathON();
                sensorL.GetComponent<Breath>().BreathON();
                switchON = true;
            }
           // sensorR.GetComponent<Breath>().BreathON();
           // sensorL.GetComponent<Breath>().BreathON();
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (switchON == false)
            {
                sensorR.GetComponent<Breath>().BreathON();
                sensorL.GetComponent<Breath>().BreathON();
                switchON = true;
            }
            // sensorR.GetComponent<Breath>().BreathON();
            // sensorL.GetComponent<Breath>().BreathON();
        }
    }
}
