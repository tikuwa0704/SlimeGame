using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject WallPrefab;//石を放つ
    public float speed;  // 移動スピード;
    public float timeOut;
    private float timeElapsed;
    public bool switchON = false;
    public void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut&&switchON==false)
        {
            StoneON();
            switchON = true;
        }
    }
    public void StoneON()
    {
        GameObject stone = (GameObject)Instantiate(WallPrefab, transform.position, Quaternion.identity);
       // Rigidbody ballRigidbody = stone.GetComponent<Rigidbody>();
       // ballRigidbody.AddForce(transform.forward * speed);
    }
}
