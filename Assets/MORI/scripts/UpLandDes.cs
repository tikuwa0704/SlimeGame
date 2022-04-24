using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLandDes : MonoBehaviour
{
    public float up = 0.01f;
    public float timeOut;
    private float timeElapsed;
    public void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            Destroy(this.gameObject);
            timeElapsed = 0.0f;
        }
    }
    public void FixedUpdate()
    {
        transform.Translate(0f, up, 0f);
    }
}
