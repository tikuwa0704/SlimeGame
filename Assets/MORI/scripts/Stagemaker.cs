using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagemaker : MonoBehaviour
{
    public GameObject StagePrefab;
    public GameObject Switch1;
    public GameObject Switch2;
    public bool ON = false;
    // Update is called once per frame
    void Update()
    {
        if(Switch1.GetComponent<WSwitch1>().Switch==true&& Switch2.GetComponent<WSwitch1>().Switch == true&&ON==false)
        {
            Stage();
            ON = true;
        }
    }

    public void Stage()
    {
        GameObject stage = (GameObject)Instantiate(StagePrefab, transform.position, Quaternion.identity);
    }
}
