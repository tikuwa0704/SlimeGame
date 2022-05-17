using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiraku : MonoBehaviour
{
    public GameObject Kesiteiru;
    public GameObject Kesiteiru2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (Random.Range(0,1000) == 0)
            {
                Hirakimasu2();
            }
            else
            {
                Hirakimasu();
            }
        }
    }

    public void Hirakimasu()
    {
        Kesiteiru.SetActive(true);
    }

    public void Hirakimasu2()
    {
        Kesiteiru2.SetActive(true);
    }
}
