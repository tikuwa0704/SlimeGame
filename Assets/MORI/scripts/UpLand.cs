using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLand : MonoBehaviour
{
    public GameObject LandPrefab;//‘«ê
    public float timeOut;
    private float timeElapsed;
    public void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            StoneON();
            timeElapsed = 0.0f;
        }
    }
    public void StoneON()
    {
        GameObject stone = (GameObject)Instantiate(LandPrefab, transform.position, Quaternion.identity);
        //Rigidbody ballRigidbody = stone.GetComponent<Rigidbody>();
       // ballRigidbody.AddForce(transform.forward * speed);
    }
}
