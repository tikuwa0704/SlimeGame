using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//雪玉の詳細
public class SnowBalls : MonoBehaviour
{
    //スケールを変える速度
    private Vector3 speed = new Vector3(1f, 1f, 1f);

    // Update is called once per frame
    void Update()
    {
        //-=で徐々にスケールを小さくする
        transform.localScale += speed * Time.deltaTime;
        Invoke("Des", 3);
    }

    public void Des()
    {
        Destroy(this.gameObject);
    }
}
