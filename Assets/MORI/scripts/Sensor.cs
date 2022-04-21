using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public GameObject sensorR;
    public GameObject sensorL;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sensorR.GetComponent<Breath>().BreathON();
            sensorL.GetComponent<Breath>().BreathON();
        }
    }
}
