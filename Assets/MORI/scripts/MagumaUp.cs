using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagumaUp : MonoBehaviour
{
    public bool Upswitch = false;
    public float up;
    // Update is called once per frame
    void Update()
    {
        if (Upswitch == true)
        {
            transform.Translate(0f, up, 0f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Upswitch = false;
            this.transform.Translate(new Vector3(-18.3f, -1.0f, 41.59f));
        }
    }
}
