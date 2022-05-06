using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoukutuLand : MonoBehaviour
{
    public float up = 0.01f;
    public bool col = false;

    public void FixedUpdate()
    {
        if (col == true)
        {
            transform.Translate(0f, up, 0f);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            col = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
