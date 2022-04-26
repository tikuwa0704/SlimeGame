using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hakai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zikken")
        {
            Rigidbody Dummy = this.GetComponent<Rigidbody>();
            if (Dummy)
            {
                Destroy(Dummy);
            }
            foreach (Transform k in this.transform)
            {
                k.gameObject.AddComponent<Rigidbody>();
                k.transform.parent = null;
                k.gameObject.AddComponent<HakaiTime>();
                /*
                float Dtime = Random.Range(1.0f, 3.0f);
                Destroy(k.gameObject, Dtime);
                */
            }
            Destroy(this.gameObject);
        }
    }
}
