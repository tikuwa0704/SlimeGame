using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeNumCount : MonoBehaviour
{

    private Text text;

    [SerializeField] private SlimeConcentration controller;

    private void Start()
    {


        text = GetComponent<Text>();
    }

    private void Update()
    {

        if (controller == null) return;

        int SlimeNum = controller.m_sticking_slime_num;
        int MaxSlimeNum = 100;


        text.text = $"{SlimeNum}/{MaxSlimeNum}";


    }

}
