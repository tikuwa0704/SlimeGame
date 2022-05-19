using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamihubuki : MonoBehaviour
{
    public GameObject G_Kamihubuki1;
    public GameObject G_Kamihubuki2;
    public GameObject G_Kamihubuki3;
    public GameObject G_Kamihubuki4;
    public GameObject G_Kamihubuki5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Deruyo();
        }
    }

    public void Deruyo()
    {
        G_Kamihubuki1.SetActive(true);
        G_Kamihubuki2.SetActive(true);
        G_Kamihubuki3.SetActive(true);
        G_Kamihubuki4.SetActive(true);
        G_Kamihubuki5.SetActive(true);
    }
}
