using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShower : MonoBehaviour
{
    public GameObject Slime;
    public int Heel = 0;//ƒXƒ‰ƒCƒ€ŒÂ”

    public void slimeshower()
    {
        if (SlimeManager.Instance)
        {
            SlimeManager.Instance.GenerateSlime(new Vector3(-80.4f, 61.4f, 384.1f));
        }
        //GameObject slime = (GameObject)Instantiate(Slime, transform.position, Quaternion.identity);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Heel <= 99)
            {
                slimeshower();
                Heel++;
            }
        }
    }
}
