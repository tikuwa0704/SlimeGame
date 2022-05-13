using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandUD : MonoBehaviour
{
    public GameObject Magma;
    public bool Down=false;
    public float down;

    public void Update()
    {
        if (Down == true)
        {
            transform.Translate(0f, down, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Down = true;
        }
    }
}
