using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageON : MonoBehaviour
{
    public GameObject stage35;
    public GameObject stonemaker;
    public GameObject Goal;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stage35.SetActive(true);
            Destroy(stonemaker.gameObject);
            Destroy(Goal.gameObject);
        }
    }
}
