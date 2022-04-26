using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HakaiTime : MonoBehaviour
{
    public float m_size;
    // Start is called before the first frame update
    void Start()
    {
        m_size = Random.Range(10.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float Xsize = this.transform.localScale.x;
        Xsize -= m_size * Time.deltaTime;
        if (Xsize <= 0.001f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.transform.localScale = new Vector3(Xsize, Xsize, Xsize);
        }
    }
}
