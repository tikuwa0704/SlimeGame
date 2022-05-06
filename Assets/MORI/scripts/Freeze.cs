using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public GameObject BreathPrefab;//炎や氷のブレスを放つ
    public bool on = false;
    public void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
            if (on == false)
            {
                BreathPrefab.SetActive(true);
                on = true;
            }

        }
    }
   /* private void OnCollisionExit(Collision collision)
    {
        //SlimeChildren（略:SC）
        if (collision.gameObject.tag == "SC")
        {
            BreathPrefab.SetActive(false);
            on = false;
        }
    }*/
   

}
