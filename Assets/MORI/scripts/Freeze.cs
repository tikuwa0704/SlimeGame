using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public GameObject BreathPrefab;//����X�̃u���X�����
    public bool on = false;
    public void OnCollisionEnter(Collision collision)
    {
        //SlimeChildren�i��:SC�j
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
        //SlimeChildren�i��:SC�j
        if (collision.gameObject.tag == "SC")
        {
            BreathPrefab.SetActive(false);
            on = false;
        }
    }*/
   

}
