using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownNumber : MonoBehaviour
{

    [SerializeField] Text countDownNumber;

    [SerializeField] public float time;

    private void Awake()
    {
        countDownNumber = this.GetComponent<Text>();
    }

    void SetUp(float _time)
    {
        time = _time;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (-5.0f <= time)
        {
            if (0 >= time)
            {

                countDownNumber.text = "GAMESTART!";

            }
            else

                countDownNumber.text = time.ToString("F0");
        }
        else
        {
            countDownNumber.enabled = false;
        }
       
    }
}
