using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour
{
    public GameObject BreathPrefab;//‰Š‚â•X‚ÌƒuƒŒƒX‚ð•ú‚Â
   // public float speed;
    public void BreathON()
    {
        GameObject breath = (GameObject)Instantiate(BreathPrefab, transform.position, Quaternion.identity);
       // Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
       // ballRigidbody.AddForce(transform.forward * speed);
    }
}
