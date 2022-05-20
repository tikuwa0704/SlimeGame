using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickSwitch : MonoBehaviour
{

    public GameObject Gimmick1;
    public GameObject Gimmick2;
    public GameObject Gimmick3;
    public static  bool gimmick1 = false;
    public static  bool gimmick2 = false;
    public static  bool gimmick3 = false;

    public void Update()
    {
        if(gimmick1==true&& gimmick2 == false && gimmick3 == false)
        {
            //Gimmick１だけをオンにする
            Gimmick1.SetActive(true);
            Gimmick2.SetActive(false);
            Gimmick3.SetActive(false);
        }
       else if (gimmick1 == false && gimmick2 == true && gimmick3 == false)
        {
            //Gimmick２だけをオンにする
            Gimmick2.SetActive(true);
            Gimmick1.SetActive(false);
            Gimmick3.SetActive(false);
        }
        else if (gimmick1 == false && gimmick2 == false && gimmick3 == true)
        {
            //Gimmick３だけをオンにする
            Gimmick3.SetActive(true);
            Gimmick2.SetActive(false);
            Gimmick1.SetActive(false);
        }
    }
}
