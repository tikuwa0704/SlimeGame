using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySlime : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SC"))
        {
            Destroy(collision.gameObject);
        }
    }


}
