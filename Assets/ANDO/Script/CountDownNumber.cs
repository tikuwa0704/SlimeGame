using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownNumber : MonoBehaviour
{

    [SerializeField] Text countDownNumber;

    [SerializeField] float time;
   
    // Start is called before the first frame update
    void Start()
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
