using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opning : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;

    GameObject botton;

    Image m_img;

    float t;

    // Start is called before the first frame update
    void Start()
    {
        botton = GameObject.Find("CLICK ON THE SCREEN");

        m_img = GetComponent<Image>();

        t = 1.0f;

        soundManager.Play("test");
    }

    // Update is called once per frame
    void Update()
    {
        if (t >= 0)
        {
            m_img.color = new Color(m_img.color.r, m_img.color.g, m_img.color.b, t);

            t -= Time.deltaTime / 3.0f;
            if (t < 0)
            {
                botton.GetComponent<Button>().enabled = true;
                this.GetComponent<Opning>().enabled = false;
            }

        }
    }
}
