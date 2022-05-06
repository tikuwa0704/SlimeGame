using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLand2 : MonoBehaviour
{
    public GameObject LandPrefab;//ë´èÍ
    public void ElevatorON()
    {
        GameObject stone = (GameObject)Instantiate(LandPrefab, transform.position, Quaternion.identity);
        //Rigidbody ballRigidbody = stone.GetComponent<Rigidbody>();
        // ballRigidbody.AddForce(transform.forward * speed);
    }
}
