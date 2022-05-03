using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDes : MonoBehaviour
{
    public float timeOut;
    private float timeElapsed;
    public void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            timeElapsed = 0.0f;
            Destroy(this.gameObject);
        }
    }
}
