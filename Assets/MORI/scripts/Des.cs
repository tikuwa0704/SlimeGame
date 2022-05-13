using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "SC")
        {
            Destroy(collision.gameObject);
        }
    }
}
