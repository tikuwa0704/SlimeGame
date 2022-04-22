using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject StonePrefab;//炎や氷のブレスを放つ
    public float speed;  // 移動スピード;
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
        GameObject stone = (GameObject)Instantiate(StonePrefab, transform.position, Quaternion.identity);
         Rigidbody ballRigidbody = stone.GetComponent<Rigidbody>();
         ballRigidbody.AddForce(transform.forward * speed);
    }
}
