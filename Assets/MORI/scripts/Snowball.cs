using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public GameObject SnowBallPrefab;
    public GameObject SnowBallPrefab2;
   // public GameObject SnowBallPrefab3;
    public float speed;  // 移動スピード;
    public void Exciting()
    {
        GameObject ball = (GameObject)Instantiate(SnowBallPrefab, transform.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(-transform.right * speed);
        Invoke("Exciting", 2);
    }

    public void Exciting2()
    {
        GameObject ball = (GameObject)Instantiate(SnowBallPrefab2, transform.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(transform.right * speed);
        Invoke("Exciting2", 2);
    }
}
